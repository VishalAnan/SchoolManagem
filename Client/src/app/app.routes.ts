import { Routes } from '@angular/router';
import { RankedListComponent } from './ranked-list/ranked-list.component';
import { StudentComponent } from './student/student.component';
import { MarksListComponent } from './marks-list/marks-list.component';
import { MarksListAddComponent } from './marks-list-add/marks-list-add.component';
import { AddStudentComponent } from './add-student/add-student.component';

export const routes: Routes = [
    {
        path:'',
        component:RankedListComponent,

    },
    {
        path:'student',
        component:StudentComponent
    },
    {
        path:'marks',
        component:MarksListComponent
    },
    {
        path:'marks/add',
        component:MarksListAddComponent
    },
    {
        path:'Add/student',
        component:AddStudentComponent

    }
];
