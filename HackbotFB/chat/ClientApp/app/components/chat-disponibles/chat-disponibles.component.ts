import { Component, OnInit } from '@angular/core';
import { MensajesServiceService } from '../../services/mensajes-service.service';

@Component({
  selector: 'app-chat-disponibles',
  templateUrl: './chat-disponibles.component.html',
  styleUrls: ['./chat-disponibles.component.css']
})
export class ChatDisponiblesComponent implements OnInit {

  constructor(private mensajesService:MensajesServiceService) { 
    
  }

  ngOnInit() {
  }

}
