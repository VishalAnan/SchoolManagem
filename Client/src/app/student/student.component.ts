import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common'; // Import CommonModule
import { IStudent } from '../models/student';
import { StudentService } from '../services/student.service.service'; // Corrected the import path

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule], // Add CommonModule here
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css'] // Ensure correct plural 'styleUrls'
})
export class StudentComponent {
  employeList: IStudent[] = [];
  studentService = inject(StudentService); // Corrected to use the proper service

  ngOnInit() {
    debugger
    this.studentService.getAllStudents().subscribe(result => { // Corrected the method name
      this.employeList = result;
      console.log(this.employeList);
    });
  }
}
