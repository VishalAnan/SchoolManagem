import { Component, OnInit } from '@angular/core';
import { IMark } from '../models/marks';
import { StudentService } from '../services/student.service.service';
import { Observable } from 'rxjs';
import { IStudent } from '../models/student';
import { ISubject } from '../models/subject';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-marks-list-add',
  standalone: true,
  imports: [CommonModule, FormsModule,],
  templateUrl: './marks-list-add.component.html',
  styleUrls: ['./marks-list-add.component.css']
})
export class MarksListAddComponent implements OnInit {
  newMark: IMark = {
    markId: 0,
    studentId: 0,
    subjectId: 0,
    score: 0
  };
  students$: Observable<IStudent[]> | undefined;
  subject$: Observable<ISubject[]> | undefined;
  isLoading = true;

  constructor(private studentService: StudentService) { }

  ngOnInit(): void {
    this.students$ = this.studentService.getAllStudents();
    this.subject$ = this.studentService.getSubject();
    this.students$.subscribe(() => this.isLoading = false);
    this.subject$.subscribe(() => this.isLoading = false);
  }

  // Method to add marks
  addMarks(): void {
    this.newMark.studentId = Number(this.newMark.studentId);
    this.newMark.subjectId = Number(this.newMark.subjectId);
    this.newMark.score = Number(this.newMark.score);


    if (this.newMark.studentId && this.newMark.subjectId && this.newMark.score) {
      this.studentService.addMarks(this.newMark).subscribe(
        (response) => {
          console.log('Marks added successfully:', response);
          alert('Marks added successfully!');
          this.newMark = {
            markId: 0,
            studentId: 0,
            subjectId: 0,
            score: 0
          };
        },
        (error) => {
          alert('Failed to add marks. Please try again.');
        }
      );
    } else {
      alert('Please fill in all fields.');
    }
  }
}
