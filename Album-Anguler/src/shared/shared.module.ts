import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UIModule } from './ui/ui.module';
import { SharedRoutingModule } from './shared-routing.module';

@NgModule({
  declarations: [],
  imports: [CommonModule, SharedRoutingModule],
  exports: [UIModule],
})
export class SharedModule {}
