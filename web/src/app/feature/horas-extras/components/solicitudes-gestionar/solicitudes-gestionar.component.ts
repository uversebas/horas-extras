import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { SolicitudHorasExtra } from '../../models/solicitudHorasExtras';
import { MatTableDataSource } from '@angular/material/table';
import { HorasExtrasService } from '../../services/horas-extras.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AprobarSolicitudComponent } from '../aprobar-solicitud/aprobar-solicitud.component';

@Component({
  selector: 'app-solicitudes-gestionar',
  templateUrl: './solicitudes-gestionar.component.html',
  styleUrls: ['./solicitudes-gestionar.component.sass']
})
export class SolicitudesGestionarComponent implements OnInit, AfterViewInit {
  @ViewChild(MatSort) sort!: MatSort;
  misSolicitudes = new MatTableDataSource<SolicitudHorasExtra>();
  numeroSolicitudes = 0;
  active!: string;
  direction!: string;
  esAscendente = true;
  displayedColumns: string[] = ['tipo', 'dias', 'estado', 'fecha', 'detalle'];

  constructor(private horasExtraService: HorasExtrasService, private changeDetectorRef: ChangeDetectorRef, private modalService: NgbModal) {}

  ngOnInit(): void {
    this.listInTable();
  }

  ngAfterViewInit() {
    this.misSolicitudes.sort = this.sort;
  }

  onSortData() {
    this.active = this.sort.active;
    this.direction = this.sort.direction;
    if (this.direction == 'asc')
      this.esAscendente = false;
    else
      this.esAscendente = true;
    this.listInTable();
  }

  listInTable() {
    const idColaborador = sessionStorage.getItem('idColaborador');
    this.horasExtraService.obtenerSolicitudesAGestionar(idColaborador!).subscribe(
      {
        next: (respuesta) => {
          this.numeroSolicitudes = respuesta.length;
          this.misSolicitudes = new MatTableDataSource<SolicitudHorasExtra>(respuesta);
        },
        complete: () => {
          if (this.numeroSolicitudes > 0) {
            this.changeDetectorRef.detectChanges();
          }
        }
      }
    );
  }

  verDetalle(row: SolicitudHorasExtra) {
    const modalref = this.modalService.open(AprobarSolicitudComponent, {size: 'lg'});
    modalref.componentInstance.solicitud = row;
    modalref.componentInstance.horasExtraService = this.horasExtraService;
  }

}
