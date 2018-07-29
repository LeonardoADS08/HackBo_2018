import { Component, OnInit,NgZone } from '@angular/core';
import { MensajesServiceService } from '../../services/mensajes-service.service';
import { SignalRService } from '../../services/SignalR.service';
import { Http } from '@angular/http';
import {MensajesDePersona } from '../../clases/MensajesDePersona';

@Component({
  selector: 'app-ventana-chat',
  templateUrl: './ventana-chat.component.html',
  styleUrls: ['./ventana-chat.component.css']
})
export class VentanaChatComponent implements OnInit {

  constructor(private mensajesService:MensajesServiceService,private signalRservice:SignalRService,private http:Http,private zone:NgZone) {
      var s = this;
      this.signalRservice.YaConecto.subscribe(() => {
          this.http.get("/home/getCosa").subscribe((a: any) => {
              this.signalRservice.mandarIdAuth(a._body);
              console.log("CUACK");
          });
      });
   

      window.addEventListener("beforeunload", function (event) {
          s.signalRservice.pararSignal();
          event.preventDefault();
          console.log("asdfsfdsfdsdfs");
          this.window.prompt("aaa");
          s.signalRservice.desconexion();
         
      });
      s.signalRservice.llegoMensaje.subscribe((recibio:any) => {
          console.log("recibio");
          console.log(recibio);
          let algo=s.mensajesService.listaMensajes.find(x => x.persona.conexion == recibio.idFacebook);
          if (algo == undefined) {
              s.mensajesService.listaMensajes.push({ Mensajes: [{ texto: recibio.mensaje, tipo: "llegada" }], persona: { conexion: recibio.idFacebook, nombre: recibio.nombre } })
           
            
          }
          else {
              algo.Mensajes.push({ texto: recibio.mensaje,tipo:"llegada"})
              
          }
          if (s.mensajesService.listaMensajes.length == 1) {
              s.mensajesService.personaSeleccionada = s.mensajesService.listaMensajes[0];
          }
          s.zone.run(() => { }) 
      });
  }

    EnviarMensaje(mensaje: any,e: any) {

     console.log(mensaje.value);
    if(mensaje.value!="")
    {
      this.mensajesService.personaSeleccionada.Mensajes.push({texto:mensaje.value,tipo:'enviado'})
        console.log(this.mensajesService.personaSeleccionada);
        this.signalRservice.mandarAlgo(this.mensajesService.personaSeleccionada.persona.conexion, mensaje.value);

    }
   
       e.scrollTop = e.scrollHeight; //- e.getBoundingClientRect().height;
        mensaje.value = "";
        
    }
  ngOnInit() {
  }

}
