import { Directive, HostListener, HostBinding } from '@angular/core';

@Directive({
  selector: '[appDropdowndirective]'
})
export class DropdownDirective {
  @HostBinding('class.open') isOpen = false;
  private wasInside = false;


@HostListener('click') toggleOpen() {
  this.isOpen = !this.isOpen;
  this.wasInside = false;
}
}
