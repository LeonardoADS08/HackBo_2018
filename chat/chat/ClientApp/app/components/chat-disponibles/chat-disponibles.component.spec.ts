import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatDisponiblesComponent } from './chat-disponibles.component';

describe('ChatDisponiblesComponent', () => {
  let component: ChatDisponiblesComponent;
  let fixture: ComponentFixture<ChatDisponiblesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChatDisponiblesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChatDisponiblesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
