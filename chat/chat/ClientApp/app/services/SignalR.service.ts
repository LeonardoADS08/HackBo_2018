
import { Injectable } from '@angular/core';
declare var $: any;

@Injectable()
export class SignalRService {
   
    conexion: any;
    constructor() {
        this.conexion = $.connection.chatHub;
        $.connection.hub.url = "http://localhost:55309/signalr/hubs";
        $.connection.hub.start()
            .done(function () { console.log('Now connected, connection ID=' + $.connection.hub.id); })
            .fail(function (sssss:any) { console.log('Could not Connect!');console.log(sssss) });
    }
    mandarAlgo(id: string, mensaje: string) {
        id = "2119200008150269";
        console.log(mensaje);
        this.conexion.invoke("Send", id, mensaje).catch((err: any) => console.error(err.toString()));
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
}
