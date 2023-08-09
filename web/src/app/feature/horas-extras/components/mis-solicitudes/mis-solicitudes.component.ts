import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { SolicitudHorasExtra } from '../../models/solicitudHorasExtras';
import { MatSort } from '@angular/material/sort';
import { HorasExtrasService } from '../../services/horas-extras.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { DetalleSolicitudComponent } from '../detalle-solicitud/detalle-solicitud.component';

@Component({
  selector: 'app-mis-solicitudes',
  templateUrl: './mis-solicitudes.component.html',
  styleUrls: ['./mis-solicitudes.component.sass']
})
export class MisSolicitudesComponent implements OnInit, AfterViewInit {

  @ViewChild(MatSort) sort!: MatSort;
  misSolicitudes = new MatTableDataSource<SolicitudHorasExtra>();
  numeroSolicitudes = 0;
  active!: string;
  direction!: string;
  esAscendente = true;
  displayedColumns: string[] = ['tipo', 'dias', 'estado', 'fecha', 'detalle'];

  constructor(private horasExtraService: HorasExtrasService, private changeDetectorRef: ChangeDetectorRef, private modalService: NgbModal) { }

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
    this.horasExtraService.obtenerMisSolicitudes(idColaborador!).subscribe(
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
    const modalref = this.modalService.open(DetalleSolicitudComponent, {size: 'lg'});
    modalref.componentInstance.solicitud = row;
  }

}
