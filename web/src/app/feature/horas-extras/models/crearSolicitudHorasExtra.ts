import { EnumTipoSolicitud } from "./enum-tipoSolicitud";

export interface CrearSolicitudHorasExtra {
    colaboradorId: string;
    tipoSolicitud: EnumTipoSolicitud;
    cantidadDias: number;
    motivo: string;
}