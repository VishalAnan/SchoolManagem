import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IRank } from '../models/RankList';
import { StudentService } from '../services/student.service.service';

@Component({
  selector: 'app-ranked-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './ranked-list.component.html',
  styleUrl: './ranked-list.component.css'
})
export class RankedListComponent {
  rank: IRank[] = [];
  studentService = inject(StudentService); // Corrected to use the proper service

  ngOnInit() {
    debugger
    this.studentService.getAllRankList().subscribe(result => { // Corrected the method name
      this.rank = result;
      console.log(this.rank);
    });
  }
}
