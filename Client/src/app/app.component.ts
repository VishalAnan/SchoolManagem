import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { StudentComponent } from "./student/student.component";
import { AddStudentComponent } from "./add-student/add-student.component";
import { MarksListComponent } from "./marks-list/marks-list.component";
import { RankedListComponent } from "./ranked-list/ranked-list.component";
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,RouterLink,RouterLinkActive,CommonModule, StudentComponent, AddStudentComponent, MarksListComponent, RankedListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SchoolManagement2';
}
