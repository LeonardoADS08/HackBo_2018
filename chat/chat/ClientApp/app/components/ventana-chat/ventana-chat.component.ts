import { Component, OnInit } from '@angular/core';
import { MensajesServiceService } from '../../services/mensajes-service.service';
import { SignalRService } from '../../services/SignalR.service';
import { Http } from '@angular/http';

@Component({
  selector: 'app-ventana-chat',
  templateUrl: './ventana-chat.component.html',
  styleUrls: ['./ventana-chat.component.css']
})
export class VentanaChatComponent implements OnInit {

  constructor(private mensajesService:MensajesServiceService,private signalRservice:SignalRService,private http:Http) {
      var s = this;
      window.addEventListener("beforeunload", function (event) {
          s.signalRservice.pararSignal();
          event.preventDefault();
          console.log("asdfsfdsfdsdfs");
          this.window.prompt("aaa");
          s.signalRservice.desconexion();
         
      });
   }
    EnviarMensaje(mensaje: any,e: any) {
        this.http.get("/home/getCosa").subscribe((a:any) => {
            console.log(a._body);
            this.signalRservice.mandarIdAuth(a._body)
        });
     console.log(mensaje.value);
    if(mensaje.value!="")
    {
      this.mensajesService.personaSeleccionada.Mensajes.push({texto:mensaje.value,tipo:'enviado'})
        console.log(this.mensajesService.personaSeleccionada);
        this.signalRservice.mandarAlgo("aaaa", mensaje.value);

    }
   
       e.scrollTop = e.scrollHeight; //- e.getBoundingClientRect().height;
        mensaje.value = "";
        
    }
  ngOnInit() {
  }

}
