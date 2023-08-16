import { Time } from "@angular/common";
import { TaskCategory } from "./task-category";

export interface Task {
    title: string,
    completed: boolean,
    timeToCompletion: number,
    editMode?: boolean,
    taskCategory?: TaskCategory,
}
