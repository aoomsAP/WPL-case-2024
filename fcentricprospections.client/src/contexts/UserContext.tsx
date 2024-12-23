// Implement UserContext
import React, { useEffect, useState } from "react";
import { IAppointment, IEmployee, IUser } from "../types";

interface UserContext {
    // states
    userId: number | undefined,
    setUserId: (userId: number) => void,
    user: IUser | undefined,
    setUser: (user: IUser) => void,
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
    userId: 0,
    setUserId: () => { },
    user: {} as IUser,
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

    // loading functions
    loadUser: async () => { },
    loadUsers: async () => { },
    loadEmployee: async () => { },
    loadEmployees: async () => { },
    loadAppointments: async () => { },
    loadAppointmentShown: async () => [],
});

export const UserProvider = ({ children }: { children: React.ReactNode }) => {

    const [userId, setUserId] = useState<number>();
    const [user, setUser] = useState<IUser>();
    const [users, setUsers] = useState<IUser[]>([]);
    const [employee, setEmployee] = useState<IEmployee>();
    const [employees, setEmployees] = useState<IEmployee[]>([]);
    const [appointments, setAppointments] = useState<IAppointment[]>([]);

    // Voor de agenda, dit zijn de afspraken die getoond worden
    const [shownAppointments, setShownAppointments] = useState<IAppointment[]>([]);

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
            const response = await fetch(`/api/users/${userId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IUser | undefined = await response.json();
            setUser(json);

            console.log("user loaded", json);

        } catch (error) {
            console.error('Error fetching userdata data:', error);
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

    // Load user specific data upon receiving userId
    useEffect(() => {
        if (userId) {
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
            setUserId: setUserId,
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