
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
    mandarAlgo() {
        this.conexion.invoke("Send").catch((err:any) => console.error(err.toString()));
    }

}
