import { Component, inject } from '@angular/core';
import { IMark } from '../models/marks';
import { StudentService } from '../services/student.service.service';
import { CommonModule } from '@angular/common';
import { IMarkView } from '../models/marksViewModel';

@Component({
  selector: 'app-marks-list',
  standalone: true,
  
  imports: [CommonModule], // Add CommonModule here

  templateUrl: './marks-list.component.html',
  styleUrl: './marks-list.component.css'
})
export class MarksListComponent {
  mark: IMarkView[] = [];
  studentService = inject(StudentService); // Corrected to use the proper service

  ngOnInit() {
    debugger
    this.studentService.getAllMarkss().subscribe(result => { // Corrected the method name
      this.mark = result;
      console.log(this.mark);
    });
  }
}
