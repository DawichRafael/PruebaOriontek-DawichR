import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '@environment/environment';
import { Observable } from 'rxjs';

@Injectable()
export class ClientesService {

  constructor(public http: HttpClient ) { }

  obtenerCliente(idCliente: Number): Promise<any> {
    return this.http.get(`${environment.api}/api/Operation/SeleccionarCliente?Id=${idCliente}`).toPromise();
  }

  obtenerDireccion(idDireccion: Number): Promise<any> {
    return this.http.get(`${environment.api}/api/Operation/SeleccionarDireccion?Id=${idDireccion}`).toPromise();
  }



//   obtenerFacturas(contrato: any): Promise<any> {
//     const body = {
//       busqueda: contrato
//     };
//     return this.http.post(`${environment.apiApoloWeb}/api/Consult/BuscarFacturas`, contrato).toPromise();
//   }

 

//   obtenerCombo(obj: any): Observable<any> {
//     return this.http.post(`${environment.apiApoloWeb}/api/Consult/Combo`, obj);
//   }

  obtenerTipoNovedad(): Observable<any> {
    return this.http.get(`${environment.api}/api/Consult/obtenerTipoNovedad?tipoProducto=03`);
  }
}
