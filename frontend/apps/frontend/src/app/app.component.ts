import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent{
  combobox1: string = 'Klasse 1';
  combobox2: string = 'Fach A';
  search: string = '';
  username: string = 'Robert Grüneis';

  tableData: any[] = [
    { name: 'John Doe', age: 30, email: 'john@example.com', warning: false },
    { name: 'Jane Smith', age: 25, email: 'jane@example.com', warning: false },
  ];

  toggleCheckbox(data: any): void {
    data.warning = !data.warning;
  }

  onSearch() {
    console.log('Search button clicked');
  }

  onCustomButtonClick() {
    console.log('Custom button clicked');
  }
}
