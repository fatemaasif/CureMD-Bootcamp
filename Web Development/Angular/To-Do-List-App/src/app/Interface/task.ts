import { Time } from "@angular/common";

export interface Task {
    title: string,
    completed: boolean,
    editMode?: boolean,
    timeToCompletion?: number
}
