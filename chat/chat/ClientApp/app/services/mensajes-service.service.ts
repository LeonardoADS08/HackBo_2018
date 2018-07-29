import { Injectable } from '@angular/core';
import {MensajesDePersona} from '../clases/MensajesDePersona';
import {Mensaje} from '../clases/Mensaje';
import {Persona} from '../clases/Persona';
@Injectable()
export class MensajesServiceService {
  personaSeleccionada:MensajesDePersona;
  listaMensajes:Array<MensajesDePersona>;
  constructor() {
    let i;
    this.listaMensajes=new Array<MensajesDePersona>();
  
    for(i=0;i<20;i++)
    {
      
      this.listaMensajes.push({persona:{conexion:""+i,nombre:"Persona"+i},Mensajes:new Array<Mensaje>()});
      
      this.Rellenar(this.listaMensajes[i],100);
      if(i==0)
      {
        this.personaSeleccionada=this.listaMensajes[0];
      }
    }
    //console.log(this.personaSeleccionada)
    //console.log(this.listaMensajes);
   }
   
   Rellenar(mensajes:MensajesDePersona,parametro:number):void{
    let i=0;
    for(;i<parametro;i++)
    {
        if(i%2==0)
            mensajes.Mensajes.push({texto:'hola'+i,tipo:'llegada'});
        else
            mensajes.Mensajes.push({texto:'hola'+i,tipo:'enviado'});
    }
};

}

