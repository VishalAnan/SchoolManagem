import { Component, inject } from '@angular/core';
import { IStudent } from '../models/student';
import { CommonModule } from '@angular/common'; // Import CommonModule
import { FormsModule } from '@angular/forms'; // Import FormsModule for ngModel

import { StudentService } from '../services/student.service.service';

@Component({
  selector: 'app-add-student',
  standalone: true,

  imports: [CommonModule, FormsModule],

  templateUrl: './add-student.component.html',

  styleUrls: ['./add-student.component.css']
})
export class AddStudentComponent {
  newStudent: IStudent = {
    studentId: 0,  // or null if your API auto-generates this field
    firstName: '',
    lastName: '',
    class: ''
  };

  constructor(private studentService: StudentService) {}

  // Method to add a student using the service's `addStudent()` method
  addStudent(): void {
  debugger
  this.newStudent.studentId=0;
    this.studentService.addStudent(this.newStudent).subscribe(
      (response) => {
        console.log('Student added successfully:', response);
        alert('Student added successfully!');
        
        // Reset the form fields after submission
        this.newStudent = {
          studentId: 0,
          firstName: '',
          lastName: '',
          class: ''
        };
      },
      (error) => {
        console.error('Error adding student:', error);
        alert('Failed to add student. Please try again.');
      }
    );
  }
}
