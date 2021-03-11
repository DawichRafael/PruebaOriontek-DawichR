import { Component, OnInit, ViewChild } from '@angular/core';
import { ClientesService } from '@app/clientes/clientes.services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; 
import { ToastrService } from 'ngx-toastr';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatInput } from '@angular/material/input';


@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css'],
  providers: [ClientesService]
})
export class ClientesComponent implements OnInit {
  public clientForm: FormGroup;
  public pageEvent: PageEvent;
  public dataSource: MatTableDataSource<any[]>;
  public dataSource2: MatTableDataSource<any[]>;
  public loading = false;
  public length = 0;
  public length2 = 0;
  public clienteSeleccionado = [];
  public flagCrearDireccion = false;

  public displayedColumns = [
    'accion',
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
    'CodigoPostal'
  ];
  @ViewChild('paginator1', { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild('paginator2', { static: true }) paginator2: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort2: MatSort;

  @ViewChild('search', { static: false }) search: MatInput;

  constructor(private clienteService: ClientesService,
              private formBuilder: FormBuilder, 
              private toastr: ToastrService) {

                this.clientForm = this.formBuilder.group({
                  idCliente: [''],
                  nombre: [{ value: '', disabled: false }],
                  apellido: [{ value: '', disabled: false }],
                  cedula: [{ value: '', disabled: false }],
                  telefono: [{ value: '', disabled: false }],
                  nacionalidad: [{ value: '', disabled: false }],
                  estadoCivil: [{ value: '', disabled: false }],
                  idEmpresa: [{ value: 1, disabled: false }],
                  direccion: this.formBuilder.group({
                  IdDireccion:  [''],
                  direccionPrincipal:  [{ value: '', disabled: false }],
                  direccionSecundaria:  [{ value: '', disabled: false }],
                  ciudad: [{ value: '', disabled: false }],
                  provincia:   [{ value: '', disabled: false }],
                  numero: [{ value: '', disabled: false }],
                  codigoPostal: [{ value: '', disabled: false }],
                  idCliente: [{ value: '', disabled: false }]
                  })
                });
               }

   ngOnInit() {

    this.toastr.success('Bienvenido a Control de empleados')
  }

  async buscarCliente() {
    let clientes = await this.clienteService.obtenerCliente(this.clientForm.controls.idCliente.value);
    this.dataSource = new MatTableDataSource(clientes);
    this.dataSource.paginator = this.paginator
    this.dataSource.sort = this.sort;
    this.length = clientes.length;

  }

  async CrearActualizarCliente(){
    let msg = '';
    if(this.clientForm.controls.idCliente.value === '')
      msg = 'Ha insertado un cliente!'
    else
      msg = 'Ha actualizado este cliente!'

    try {
       await this.clienteService.InsertarActualizarCliente(this.clientForm.value);
  
      this.toastr.success(msg);
      this.clientForm.reset();
    } catch (err) {
      this.toastr.error(err.error.Message)
    }
  }
  async buscarDirecciones(row){
 
    let direcciones = await this.clienteService.obtenerDireccion(row.idCliente);
    this.clienteSeleccionado = await this.clienteService.obtenerCliente(row.idCliente);
    
    this.toastr.info('Puedes editar el cliente en la siguiente tab')
    this.llenarClienteTab(this.clienteSeleccionado);

    this.dataSource2 = new MatTableDataSource(direcciones);
    this.dataSource2.paginator = this.paginator2
    this.dataSource2.sort = this.sort2;
    this.length2 = direcciones.length;
  }

  llenarClienteTab(clienteSeleccionado : any){
 
    if(clienteSeleccionado !== null){
    this.clientForm.controls.idCliente.setValue(clienteSeleccionado[0].idCliente);
    this.clientForm.controls.nombre.setValue(clienteSeleccionado[0].nombre);
    this.clientForm.controls.apellido.setValue(clienteSeleccionado[0].apellido);
    this.clientForm.controls.cedula.setValue(clienteSeleccionado[0].cedula);
    this.clientForm.controls.telefono.setValue(clienteSeleccionado[0].telefono);
    this.clientForm.controls.nacionalidad.setValue(clienteSeleccionado[0].nacionalidad);
    this.clientForm.controls.estadoCivil.setValue(clienteSeleccionado[0].estadoCivil);
    this.flagCrearDireccion = true;
  }
  }
  Limpiar(){
    this.dataSource = new MatTableDataSource([]);
    this.dataSource.paginator = this.paginator
    this.dataSource.sort = this.sort;
    this.length = 0;
    this.dataSource2 = new MatTableDataSource([]);
    this.dataSource2.paginator = this.paginator2
    this.dataSource2.sort = this.sort2;
    this.length2 = 0;
    this.clientForm.reset();
    this.clienteSeleccionado = [];
    this.flagCrearDireccion = false;
  }

  async EliminarCliente(row){
 
 
    try {
      await this.clienteService.eliminarCliente(row.idCliente);
 
      this.toastr.success('Ha eliminado este cliente')
      this.clienteService.obtenerCliente(null);
   } catch (err) {
     this.toastr.error(err.error)
   }
  }
  async CrearActualizarDireccion(){
    let msg = '';
    if(this.clientForm.controls.direccion.get('IdDireccion').value === '')
      msg = 'Ha insertado una dirección !'
    else
      msg = 'Ha actualizado esta dirección!'

    try {
       await this.clienteService.InsertarActualizarDireccion(this.clientForm.value);
  
      this.toastr.success(msg);
      this.clientForm.controls.direccion.reset();
    } catch (err) {
      this.toastr.error(err.error.Message)
    }
  }
}
