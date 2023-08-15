import { Time } from "@angular/common";

export interface Task {
    title: string,
    completed: boolean,
    timeToCompletion: number,
    editMode?: boolean,
    
}
