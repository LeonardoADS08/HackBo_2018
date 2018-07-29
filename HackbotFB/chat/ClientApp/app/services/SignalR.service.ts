
import { Injectable,EventEmitter } from '@angular/core';
import { Event } from '@angular/router';
declare var $: any;

@Injectable()
export class SignalRService {
    llegoMensaje: EventEmitter<any>=new EventEmitter<any>();
    conexion: any;
    DesconectarCliente: EventEmitter<any> = new EventEmitter<any>();
    YaConecto: EventEmitter<any> = new EventEmitter<any>();
    constructor() {

        var s = this;
        this.conexion = $.connection.chatHub;
        $.connection.hub.url = "http://localhost:55309/signalr/hubs";
        $.connection.hub.start()
            .done(function () {
                console.log('Now connected, connection ID=' + $.connection.hub.id);
                s.YaConecto.emit();
            })
            .fail(function (sssss: any) { console.log('Could not Connect!'); console.log(sssss) });
        s.conexion.on("recibirMensaje", (mensaje: any, nombre:any,idFacebook:any) => {
     
            this.llegoMensaje.emit({mensaje:mensaje,nombre:nombre,idFacebook:idFacebook});
        })
    }
    mandarAlgo(id: string, mensaje: string) {
        this.conexion.invoke("Send", id, mensaje);
        //this.conexion.invoke("Send","aaaaaaa","aaaaaaa").catch((err: any) => console.error(err.toString()));
    }
    mandarIdAuth(auth:string) {
        this.conexion.invoke("RecibirConexion", auth);
    }
    desconexion() {
        this.conexion.invoke("desconexion", "aaaa");
    }
    pararSignal() {
        $.connection.hub.stop();
    }
    DesconectarClienteM(id:string) {
        this.conexion.invoke("DesconexionCliente",id);
    }
}
