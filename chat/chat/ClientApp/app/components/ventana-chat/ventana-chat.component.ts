import { Component, OnInit } from '@angular/core';
import { MensajesServiceService } from '../../services/mensajes-service.service';
import { SignalRService } from '../../services/SignalR.service';
@Component({
  selector: 'app-ventana-chat',
  templateUrl: './ventana-chat.component.html',
  styleUrls: ['./ventana-chat.component.css']
})
export class VentanaChatComponent implements OnInit {

  constructor(private mensajesService:MensajesServiceService,private signalRservice:SignalRService) {
    
   }
   EnviarMensaje(mensaje:any,e:any){
     console.log(mensaje.value==="");
    if(mensaje.value!="")
    {
      this.mensajesService.personaSeleccionada.Mensajes.push({texto:mensaje.value,tipo:'enviado'})
      console.log(this.mensajesService.personaSeleccionada);
      mensaje.value="";
    }
   
       e.scrollTop = e.scrollHeight; //- e.getBoundingClientRect().height;
       this.signalRservice.mandarAlgo();
   }
  ngOnInit() {
  }

}
