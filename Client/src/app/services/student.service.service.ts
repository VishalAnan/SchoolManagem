import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IStudent } from '../models/student';
import { Observable } from 'rxjs';
import { IMark } from '../models/marks';
import { IRank } from '../models/RankList';
import { IMarkView } from '../models/marksViewModel';
import { ISubject } from '../models/subject';

@Injectable({
  providedIn: 'root'
})
export class StudentService {
  private students: IStudent[] = [];
  private mark: IMark[] = [];
  private apiUrl = 'https://localhost:7244/api/Students';
  private apiMarksUrl = 'https://localhost:7244/api/Students/allData';
  private apiRankUrl = 'https://localhost:7244/api/Students/ranked';


  constructor(private http: HttpClient) {}

  // Fetch all students from the API
  getAllStudents() {
    return this.http.get<IStudent[]>(this.apiUrl);
  }
  getAllMarkss() {
    return this.http.get<IMarkView[]>(this.apiMarksUrl);
  }
  getAllRankList() {
    return this.http.get<IRank[]>(this.apiRankUrl);
  }
  // Add a student to the local array
  addStudent(student: IStudent): Observable<IStudent> {
    return this.http.post<IStudent>('https://localhost:7244/api/Students', student);
  }
  addMarks(mark: IMark): Observable<IMark> {
    return this.http.post<IMark>('https://localhost:7244/api/Marks', mark);
  }

  getSubject():Observable<ISubject[]>{
    return this.http.get<ISubject[]>("https://localhost:7244/api/Subject")
  }
  // Optionally get local students
  getLocalStudents(): IStudent[] {
    return this.students;
  }
}
