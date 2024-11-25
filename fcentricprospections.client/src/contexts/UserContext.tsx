// Implement UserContext
import React, { useEffect, useState } from "react";
import { IAppointment, IEmployee, IUser } from "../types";

interface UserContext {
    setUserId: (id: string) => void;
    setEmployee: (id: IEmployee) => void;
    user: IUser | undefined;
    employee: IEmployee | undefined;
    appointments: IAppointment[];

    //temp
    userList: IUser[];
}

export const UserContext = React.createContext<UserContext>({
    setUserId: () => { },
    setEmployee: () => { },
    user: {} as IUser,
    employee: {} as IEmployee,
    appointments: [],

    //temp
    userList: []
});

export const UserProvider = ({ children }: { children: React.ReactNode }) => {

    const [userId, setUserId] = useState<string>();
    const [user, setUser] = useState<IUser>();
    const [employee, setEmployee] = useState<IEmployee>();
    const [appointments, setAppointments] = useState<IAppointment[]>([]);

    //Temp state
    const [usersList, setUsersList] = useState<IUser[]>([]);

    //temp loader meerdere users
    async function loadUsersTemp() {
        try {
            const response = await fetch(`/api/users`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });
            const json: IUser[] = await response.json();
            setUsersList(json);
        }
        catch (error) {
            console.error('Error fetching userdata data:', error);
        }
    }

    useEffect(() => {
        loadUsersTemp();
        //temp
        console.log("Lijst user ingeladen")

    }, [])

    async function loadUser(userId: string) {
        try {
            const response = await fetch(`/api/users/${userId}`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IUser | undefined = await response.json();
            setUser(json);

            //temp
            console.log(json, 'functie userData wat zit erin');

        } catch (error) {
            console.error('Error fetching userdata data:', error);
        }
    }

    async function loadEmployeeData(userId: string) {
        try {
            console.log("start loading employee")

            const response = await fetch(`/api/employees/${userId}`, {
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

    async function loadAppointments(employeeId: string | undefined) {
        try {
            console.log("loading appointments");
            console.log("employee id: ", employeeId)

            const response = await fetch(`/api/employees/${employeeId}/appointments`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IAppointment[] = await response.json();

            console.log("loaded appointments", json)

            setAppointments(json);
        } catch (error) {
            console.error('Error fetching appointments data:', error);
        }
    }

    async function loadData(userId: string) {
        await loadUser(userId);
        const loadedEmployee = await loadEmployeeData(userId);

        // load appointments with newly loaded employee id
        // ! setState() is ASYNC and therefore does not contain the correct data yet
        await loadAppointments(loadedEmployee?.id);
    }

    useEffect(() => {
        if (userId) {
            loadData(userId)
            console.log("user id ", userId, ' is ingeladen')
        }
    }, [userId]);

    return (
        <UserContext.Provider value={{
            setUserId: setUserId,
            setEmployee: setEmployee,
            user: user,
            employee: employee,
            appointments: appointments,

            //temp
            userList: usersList
        }}>
            {children}
        </UserContext.Provider>
    );
}