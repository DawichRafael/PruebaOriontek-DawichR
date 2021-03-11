import { Component, OnInit, ViewChild } from '@angular/core';
import { ClientesService } from '@app/clientes/clientes.services';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
// import { ToastrService } from 'ngx-toastr';
// import { AuthService } from '@core/auth.service';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatInput } from '@angular/material/input';
//import { MAT_DATE_FORMATS } from '@angular/material/core';


@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css'],
  providers: [ClientesService]
})
export class ClientesComponent implements OnInit {
  public actionForm: FormGroup;
  public pageEvent: PageEvent;
  public dataSource: MatTableDataSource<any[]>;
  public dataSource2: MatTableDataSource<any[]>;
  public loading = false;


  public displayedColumns = [
    'IdCliente',
    'Nombres',
    'Apellidos',
    'Cedula',
    'Telefono',
    'Nacionalidad',
    'EstadoCivil',
    'Empresa'
  ];
  public displayedColumns2 = [
    'IdDireccion',
    'Direccion1',
    'Direccion2',
    'Ciudad',
    'Provincia',
    'Numero',
    'CodigoPostal',
    'Cliente'
  ];
  @ViewChild('paginator1', { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild('paginator2', { static: true }) paginator2: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort2: MatSort;

  @ViewChild('search', { static: false }) search: MatInput;

  constructor(private clienteService: ClientesService,
              private FormBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.clienteService.obtenerCliente
  }

}
