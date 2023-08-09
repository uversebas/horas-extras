import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/core/services/http.service';
import { environment } from 'src/environments/enviroment';
import { SolicitudHorasExtra } from '../models/solicitudHorasExtras';
import { Observable, catchError, throwError } from 'rxjs';
import { CrearSolicitudHorasExtra } from '../models/crearSolicitudHorasExtra';
import { AprobarSolicitudHorasExtra } from '../models/aprobarSolicitudHorasExtra';

@Injectable()
export class HorasExtrasService extends HttpService {

  constructor(protected override http: HttpClient) { super(http); }

  public obtenerMisSolicitudes(idColaborador: string): Observable<SolicitudHorasExtra[]> {
    const endpoint = `${environment.endpoint}HorasExtra/MisSolicitudes?ColaboradorId=${idColaborador}`;
    return this.doGet<SolicitudHorasExtra[]>(endpoint);
  }

  public obtenerSolicitudesAGestionar(idColaborador: string): Observable<SolicitudHorasExtra[]> {
    const endpoint = `${environment.endpoint}HorasExtra/SolicitudesGestionar?ColaboradorId=${idColaborador}`;
    return this.doGet<SolicitudHorasExtra[]>(endpoint);
  }

  public crearSolicitud(solicitud: CrearSolicitudHorasExtra): Observable<any> {
    const endpoint = `${environment.endpoint}HorasExtra/CrearSolicitud`;
    return this.doPost<CrearSolicitudHorasExtra, any>(endpoint, solicitud).pipe(
      catchError((error: HttpErrorResponse) => {
        let errorMessage = 'Error inesperado';
        if (error.error instanceof ErrorEvent) {
          errorMessage = error.error.message;
        } else {
          errorMessage = error.error.message;
        }
        return throwError(errorMessage);
      })
    );
  }

  public aprobarSolicitud(aprobacion: AprobarSolicitudHorasExtra): Observable<any> {
    const endpoint = `${environment.endpoint}HorasExtra/AprobarSolicitud`;
    return this.doPost<AprobarSolicitudHorasExtra, any>(endpoint, aprobacion);
  }
}
