// Implement UserContext
import React, { useEffect, useState } from "react";
import { IAppointment, IEmployee, IUser } from "../types";
import Cookies from "js-cookie";

interface UserContext {
    // states
    userId: number | undefined,
    setUserId: (userId: number | undefined) => void,
    user: IUser | undefined,
    setUser: (user: IUser | undefined) => void,
    users: IUser[],
    setUsers: (users: IUser[]) => void,
    employee: IEmployee | undefined,
    setEmployee: (employee: IEmployee) => void,
    employees: IEmployee[],
    setEmployees: (employee: IEmployee[]) => void,
    appointments: IAppointment[],
    setAppointments: (appointments: IAppointment[]) => void,
    shownAppointments: IAppointment[],
    setShownAppointments: (shownAppointments: IAppointment[]) => void,
    userCalendarLoading: boolean,
    userDataLoading: boolean,

    // loading functions
    loadUser: (userId: number) => void;
    loadUsers: () => void;
    loadEmployee: (userId: number) => void;
    loadEmployees: () => void;
    loadAppointments: (id: number) => void;
    loadAppointmentShown: (id: number) => Promise<IAppointment[]>;
}

export const UserContext = React.createContext<UserContext>({
    // states
    userId: undefined,
    setUserId: () => { },
    user: undefined,
    setUser: () => { },
    users: [],
    setUsers: () => { },
    employee: {} as IEmployee,
    setEmployee: () => { },
    employees: [],
    setEmployees: () => { },
    appointments: [],
    setAppointments: () => { },
    shownAppointments: [],
    setShownAppointments: () => { },
    userCalendarLoading: false,
    userDataLoading: false,

    // loading functions
    loadUser: async () => { },
    loadUsers: async () => { },
    loadEmployee: async () => { },
    loadEmployees: async () => { },
    loadAppointments: async () => { },
    loadAppointmentShown: async () => [],
});

export const UserProvider = ({ children }: { children: React.ReactNode }) => {

    const [userId, setUserId] = useState<number | undefined>(undefined);
    const [user, setUser] = useState<IUser | undefined>(undefined);
    const [users, setUsers] = useState<IUser[]>([]);
    const [employee, setEmployee] = useState<IEmployee>();
    const [employees, setEmployees] = useState<IEmployee[]>([]);
    const [appointments, setAppointments] = useState<IAppointment[]>([]);
    const [userCalendarLoading, setUserCalendarLoading] = useState<boolean>(false);
    const [userDataLoading, setUserDataLoading] = useState<boolean>(false);

    // TO DO: unused?
    // Voor de agenda, dit zijn de afspraken die getoond worden
    const [shownAppointments, setShownAppointments] = useState<IAppointment[]>([]);

    // Wrapper function to set userId alongside
    function setUserIdState(id: number | undefined) {
        setUserId(id);
        if (id) {
            Cookies.set(
                "userId",
                id.toString(),
                {
                    expires: 1,  // Expires in 1 day
                    sameSite: 'None',
                    secure: true
                },
            );
        }
        else {
            // Logout
            Cookies.remove("userId");
            setUser(undefined);
            setEmployee(undefined);
            console.log("Logged out");
        }
    }

    async function loadUsers() {
        try {
            const response = await fetch(`/api/users`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });
            const json: IUser[] = await response.json();
            setUsers(json);
        }
        catch (error) {
            console.error('Error fetching users data:', error);
        }
    }

    async function loadUser(userId: number) {
        try {
            setUserDataLoading(true);
            const response = await fetch(`/api/users/${userId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IUser | undefined = await response.json();
            setUser(json);
            setUserDataLoading(false);

            console.log("user loaded", json);

        } catch (error) {
            console.error('Error fetching userdata data:', error);
            setUserDataLoading(false);
        }
    }

    async function loadEmployees() {
        try {
            const response = await fetch(`/api/employees`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });
            const json: IEmployee[] = await response.json();
            setEmployees(json);
        }
        catch (error) {
            console.error('Error fetching employees data:', error);
        }
    }

    async function loadEmployee(userId: number) {
        try {
            console.log("start loading employee")

            const response = await fetch(`/api/employees/user/${userId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IEmployee | undefined = await response.json();
            console.log("loaded employee", json);

            setEmployee(json);

            return json;
        } catch (error) {
            console.error('Error fetching employee data:', error);
        }
    }

    // Loads, sets & returns appointments of current user
    async function loadAppointments(employeeId: number) {
        try {
            setUserCalendarLoading(true);

            console.log(`loading appointments for user-employee ${employeeId}`);

            const response = await fetch(`/api/employees/${employeeId}/appointments`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IAppointment[] = await response.json();

            console.log(`successfully loaded appointments for user-employee ${employeeId}`, json)
            setAppointments(json);
            return json;
        } catch (error) {
            console.error('Error fetching appointments data:', error);
        } finally {
            setUserCalendarLoading(false);
        }
    }

    // Loads & returns appointments for a specific user
    async function loadAppointmentShown(employeeId: number): Promise<IAppointment[]> {
        try {
            console.log(`loading appointments for employee ${employeeId}`);

            const response = await fetch(`/api/employees/${employeeId}/appointments`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IAppointment[] = await response.json();

            console.log(`successfully loaded appointments for employee ${employeeId}`, json)

            return (json);
        } catch (error) {
            console.error('Error fetching appointments data:', error);
            return ([])
        }
    }

    // Loads data based on a specific userId
    async function loadUserData(userId: number) {
        await loadUser(userId);
        const loadedEmployee = await loadEmployee(userId);

        if (loadedEmployee) {
            // Loads appointments with newly loaded employee id
            const loadedAppointments = await loadAppointments(loadedEmployee.id);

            // Sets shownAppointment with default appointments
            if (loadedAppointments) setShownAppointments(loadedAppointments);
        }
    }

    // Load userId from cookies on mount
    useEffect(() => {
        const savedUserId = Cookies.get("userId");
        if (savedUserId) {
            setUserIdState(parseInt(savedUserId, 10));
        }
    }, []);

    // Load user specific data upon receiving userId
    useEffect(() => {
        if (userId) {
            setEmployee(undefined);
            loadUserData(userId);
        }
    }, [userId]);

    // Load all users & employees upon mount
    useEffect(() => {
        loadUsers();
        loadEmployees();
    }, [])

    return (
        <UserContext.Provider value={{
            userId: userId,
            setUserId: setUserIdState, /// Use wrapper function to set cookie as well
            user: user,
            setUser: setUser,
            users: users,
            setUsers: setUsers,
            employee: employee,
            setEmployee: setEmployee,
            employees: employees,
            setEmployees: setEmployees,
            appointments: appointments,
            setAppointments: setAppointments,
            shownAppointments: shownAppointments,
            setShownAppointments: setShownAppointments,
            userCalendarLoading: userCalendarLoading,
            userDataLoading: userDataLoading,

            // loading functions
            loadUser: loadUser,
            loadUsers: loadUsers,
            loadEmployee: loadEmployee,
            loadEmployees: loadEmployees,
            loadAppointments: loadAppointments,
            loadAppointmentShown: loadAppointmentShown,
        }}>
            {children}
        </UserContext.Provider>
    );
}