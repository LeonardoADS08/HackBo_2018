import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VentanaChatComponent } from './ventana-chat.component';

describe('VentanaChatComponent', () => {
  let component: VentanaChatComponent;
  let fixture: ComponentFixture<VentanaChatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VentanaChatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VentanaChatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
