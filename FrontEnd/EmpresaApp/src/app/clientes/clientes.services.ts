import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '@environment/environment';

@Injectable()
export class ClientesService {

  constructor(public http: HttpClient ) { }

  obtenerCliente(idCliente: Number): Promise<any> {
    let requestClient = `/api/Operation/SeleccionarCliente?Id=${idCliente}`;
    if(idCliente === null){
      requestClient = `/api/Operation/SeleccionarCliente`;
    }
    return this.http.get(`${environment.api}${requestClient}`).toPromise();
  }

  obtenerDireccion(idDireccion: Number): Promise<any> {
    return this.http.get(`${environment.api}/api/Operation/SeleccionarDireccion?Id=${idDireccion}`).toPromise();
  }

  InsertarActualizarCliente(cliente: any): Promise<any> {
    const body = {
      idCliente: cliente.idCliente === '' ? null : cliente.idCliente,
      nombre:  cliente.nombre,
      apellido:  cliente.apellido,
      cedula:  cliente.cedula,
      telefono:  cliente.telefono,
      nacionalidad:  cliente.nacionalidad,
      estadoCivil: cliente.estadoCivil,
      idEmpresa: 1
    };
    return this.http.post(`${environment.api}/api/Operation/InsertarActualizarCliente`, body).toPromise();
  }

  InsertarActualizarDireccion(direccion: any): Promise<any> {
    const body = {
      idDireccion: direccion.direccion.idDireccion === '' ? null : direccion.idDireccion,
      direccionPrincipal:  direccion.direccion.direccionPrincipal,
      direccionSecundaria:  direccion.direccion.direccionSecundaria,
      ciudad:  direccion.direccion.ciudad,
      provincia:  direccion.direccion.provincia,
      numero:  direccion.direccion.numero,
      codigoPostal:  direccion.direccion.codigoPostal,
      idCliente: direccion.idCliente
    };
    return this.http.post(`${environment.api}/api/Operation/InsertarActualizarDireccion`, body).toPromise();
  }

  eliminarCliente(idCliente: Number): Promise<any> {
    return this.http.post(`${environment.api}/api/Operation/EliminarCliente?idCliente=${idCliente}`, idCliente).toPromise();
  }


  eliminarDireccion(idDireccion: Number): Promise<any> {
    return this.http.post(`${environment.api}/apiOperation/EliminarDireccion`, idDireccion).toPromise();
  }

}
