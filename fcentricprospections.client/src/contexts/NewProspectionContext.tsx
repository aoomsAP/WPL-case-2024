import { createContext, useState, useEffect } from 'react';
import { IBrand, ICompetitorBrand, IContactType, IProspectionDetail, IProspectionBrand, IProspectionBrandInterest, IProspectionCompetitorBrand, IVisitType, IToDo, IProspectionToDo } from '../types';

export interface NewProspectionContext {
    // data states
    allBrands: IBrand[];
    setAllBrands: (brands: IBrand[]) => void;
    competitorBrands: ICompetitorBrand[];
    setCompetitorBrands: (competitorBrands: ICompetitorBrand[]) => void;
    contactTypes: IContactType[];
    setContactTypes: (contactTypes: IContactType[]) => void;
    visitTypes: IVisitType[];
    setVisitTypes: (visitTypes: IVisitType[]) => void;

    // new prospection states
    prospection: IProspectionDetail | undefined;
    setProspection: (prospection: IProspectionDetail | undefined) => void;
    prospectionBrands: IProspectionBrand[];
    setProspectionBrands: (prospectionBrands: IProspectionBrand[]) => void;
    prospectionCompetitorBrands: IProspectionCompetitorBrand[];
    setProspectionCompetitorBrands: (prospectionCompetitorBrands: IProspectionCompetitorBrand[]) => void;
    prospectionBrandInterests: IProspectionBrandInterest[];
    setProspectionBrandInterests: (prospectionBrandInterests: IProspectionBrandInterest[]) => void;
    prospectionToDos: IProspectionToDo[];
    setProspectionToDos: (prospectionToDos: IProspectionToDo[]) => void;
    toDos: IToDo[];
    setToDos: (toDos: IToDo[]) => void;

    // functions
    loadBrands: () => Promise<void>;
    loadCompetitorBrands: () => Promise<ICompetitorBrand[]>;
    loadContactTypes: () => Promise<void>;
    loadVisitTypes: () => Promise<void>;

    addProspection: (newProspection: IProspectionDetail) => Promise<IProspectionDetail | undefined>;
    addToDo: (newToDo: IToDo) => Promise<IToDo | undefined>;
    updateProspectionBrands: (prospectionId: number, prospectionBrands: IProspectionBrand[]) => Promise<void>;
    updateProspectionCompetitorBrands: (prospectionId: number, prospectionCompetitorBrands: IProspectionCompetitorBrand[]) => Promise<void>;
    updateProspectionBrandInterests: (prospectionId: number, prospectionBrandInterests: IProspectionBrandInterest[]) => Promise<void>;
    updateProspectionToDos: (prospectionId: number, prospectionToDos: IProspectionToDo[]) => Promise<void>;
}

export const NewProspectionContext = createContext<NewProspectionContext>({
    // data states
    allBrands: [],
    setAllBrands: () => { },
    competitorBrands: [],
    setCompetitorBrands: () => { },
    contactTypes: [],
    setContactTypes: () => { },
    visitTypes: [],
    setVisitTypes: () => { },

    // new prospection states
    prospection: {} as IProspectionDetail | undefined,
    setProspection: () => { },
    prospectionBrands: [],
    setProspectionBrands: () => { },
    prospectionCompetitorBrands: [],
    setProspectionCompetitorBrands: () => { },
    prospectionBrandInterests: [],
    setProspectionBrandInterests: () => { },
    prospectionToDos: [],
    setProspectionToDos: () => { },
    toDos: [],
    setToDos: () => {},

    // functions
    loadBrands: () => Promise.resolve(),
    loadCompetitorBrands: () => Promise.resolve(),
    loadContactTypes: () => Promise.resolve(),
    loadVisitTypes: () => Promise.resolve(),

    addProspection: () => Promise.resolve(undefined),
    addToDo: () => Promise.resolve(undefined),
    updateProspectionBrands: () => Promise.resolve(),
    updateProspectionCompetitorBrands: () => Promise.resolve(),
    updateProspectionBrandInterests: () => Promise.resolve(),
    updateProspectionToDos: () => Promise.resolve(),
});

export function NewProspectionProvider({ children }: { children: React.ReactNode }) {

    // states  ---------------------------------------------------------------------------------------------

    // data states
    const [allBrands, setAllBrands] = useState<IBrand[]>([]);
    const [competitorBrands, setCompetitorBrands] = useState<ICompetitorBrand[]>([]);
    const [contactTypes, setContactTypes] = useState<IContactType[]>([]);
    const [visitTypes, setVisitTypes] = useState<IVisitType[]>([]);

    // new prospection states
    const [prospection, setProspection] = useState<IProspectionDetail | undefined>();
    const [prospectionBrands, setProspectionBrands] = useState<IProspectionBrand[]>([]);
    const [prospectionCompetitorBrands, setProspectionCompetitorBrands] = useState<IProspectionCompetitorBrand[]>([]);
    const [prospectionBrandInterests, setProspectionBrandInterests] = useState<IProspectionBrandInterest[]>([]);
    const [prospectionToDos, setProspectionToDos] = useState<IProspectionToDo[]>([]);
    const [toDos, setToDos] = useState<IToDo[]>([]); // TO IMPLEMENT


    // functions -------------------------------------------------------------------------------------------------

    // LOAD DATA

    async function loadBrands() {
        try {
            const response = await fetch(`/api/brands`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IBrand[] = await response.json();
            setAllBrands(json);

        } catch (error) {
            console.error('Error fetching brands data:', error);
        }
    }

    async function loadCompetitorBrands() {
        try {
            const response = await fetch(`/api/competitorbrands`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: ICompetitorBrand[] = await response.json();
            setCompetitorBrands(json);
            return json;

        } catch (error) {
            console.error('Error fetching competitor brands data:', error);
        }
    }

    async function loadContactTypes() {
        try {
            const response = await fetch(`/api/contacttypes`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IContactType[] = await response.json();
            setContactTypes(json);

        } catch (error) {
            console.error('Error fetching contact types data:', error);
        }
    }

    async function loadVisitTypes() {
        try {
            const response = await fetch(`/api/visittypes`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            });

            const json: IVisitType[] = await response.json();
            setVisitTypes(json);

        } catch (error) {
            console.error('Error fetching visit types:', error);
        }
    }

    // ADD PROSPECTION

    async function addProspection(newProspection: IProspectionDetail) {
        try {
            const response = await fetch(`/api/prospections`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newProspection),
            });

            const json: IProspectionDetail = await response.json();

            console.log("Succesful POST new prospection: ", json)
            return (json);

        } catch (error) {
            console.error('Error POST new prospection:', error);
        }
    }

    async function addToDo(newToDo: IToDo) {
        try {
            const response = await fetch(`/api/todos`, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(newToDo),
            });

            const json: IToDo = await response.json();

            console.log("Succesful POST new todo: ", json)
            return (json);
        } catch (error) {
            console.error('Error POST new todo:', error);
        }
    }

    async function updateProspectionBrands(prospectionId: number, prospectionBrands: IProspectionBrand[]) {

        try {
            const payload = { ProspectionBrands: prospectionBrands };

            await fetch(`/api/prospections/${prospectionId}/brands`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            //const json = await response.json();

            console.log("Succesful PUT prospection brands.")

        } catch (error) {
            console.error('Error PUT prospection brands:', error);
        }
    }

    async function updateProspectionBrandInterests(prospectionId: number, prospectionBrandInterests: IProspectionBrandInterest[]) {
        try {
            const payload = { ProspectionBrandInterests: prospectionBrandInterests };

            await fetch(`/api/prospections/${prospectionId}/brandinterests`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            //const json = await response.json();

            console.log("Succesful PUT prospection brand interests.")

        } catch (error) {
            console.error('Error PUT prospection brand interests:', error);
        }
    }

    async function updateProspectionCompetitorBrands(prospectionId: number, prospectionCompetitorBrands: IProspectionCompetitorBrand[]) {
        try {
            const ids: number[] = prospectionCompetitorBrands.map(x => x.competitorBrandId);

            const payload = { CompetitorBrandIds: ids };

            await fetch(`/api/prospections/${prospectionId}/competitorbrands`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            //const json = await response.json();

            console.log("Succesful PUT prospection competitor brands.")

        } catch (error) {
            console.error('Error PUT prospection competitor brands:', error);
        }
    }

    async function updateProspectionToDos(prospectionId: number, prospectionToDos: IProspectionToDo[]) {
        try {
            const ids: number[] = prospectionToDos.map(x => x.toDoId);

            const payload = { ToDoIds: ids };

            await fetch(`/api/prospections/${prospectionId}/todos`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            console.log("Succesful PUT prospection todos.")

        } catch (error) {
            console.error('Error PUT prospection todos:', error);
        }
    }

    // use effect & return ---------------------------------------------------------------------------------------------------------

    useEffect(() => {
        loadBrands();
        loadCompetitorBrands();
        loadContactTypes();
        loadVisitTypes();
    }, []);

    return (
        <NewProspectionContext.Provider value={{
            // data states
            allBrands: allBrands,
            setAllBrands: setAllBrands,
            competitorBrands: competitorBrands,
            setCompetitorBrands: setCompetitorBrands,
            contactTypes: contactTypes,
            setContactTypes: setContactTypes,
            visitTypes: visitTypes,
            setVisitTypes: setVisitTypes,

            // new prospection states
            prospection: prospection,
            setProspection: setProspection,
            prospectionBrands: prospectionBrands,
            setProspectionBrands: setProspectionBrands,
            prospectionCompetitorBrands: prospectionCompetitorBrands,
            setProspectionCompetitorBrands: setProspectionCompetitorBrands,
            prospectionBrandInterests: prospectionBrandInterests,
            setProspectionBrandInterests: setProspectionBrandInterests,
            prospectionToDos: prospectionToDos,
            setProspectionToDos: setProspectionToDos,
            toDos: toDos,
            setToDos: setToDos,

            // functions
            loadBrands: loadBrands,
            loadCompetitorBrands: loadCompetitorBrands,
            loadContactTypes: loadContactTypes,
            loadVisitTypes: loadVisitTypes,

            addProspection: addProspection,
            addToDo: addToDo,
            updateProspectionBrands: updateProspectionBrands,
            updateProspectionCompetitorBrands: updateProspectionCompetitorBrands,
            updateProspectionBrandInterests: updateProspectionBrandInterests,
            updateProspectionToDos: updateProspectionToDos,
        }}>
            {children}
        </NewProspectionContext.Provider>
    );
}