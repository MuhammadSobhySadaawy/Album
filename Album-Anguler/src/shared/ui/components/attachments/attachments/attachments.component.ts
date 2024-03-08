import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  SimpleChanges,
  ViewChild,
} from '@angular/core';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-attachments',
  templateUrl: './attachments.component.html',
  styleUrls: ['./attachments.component.scss'],
})
export class AttachmentsComponent implements OnInit {
  constructor(private ref: ChangeDetectorRef,private tost: NgToastService) {
    this.currentLang = localStorage.getItem('currentLang') || 'en';
  }

  public currentLang: string = 'en';
  // @ViewChild(ChangeDirectionDirective) directive: any;

  @Input() files?: any[];
  @Input() isMany: boolean = false;
  @Input() isRequired: boolean = false;
  @Input() displayFlex: boolean = true;
  isDisabled: boolean = false;
  myFiles!: any[];
  @ViewChild('inputFile')
  myInputVariable!: ElementRef;
  @Output() OnChangeFile = new EventEmitter<any[]>();
  ngOnInit(): void {}

  ngOnChanges(changes: SimpleChanges) {
    if (changes['files']) {
      this.files = changes['files'].currentValue;
    }

    if (this.files ? this.files.length >= 0 : false && this.files != null) {
      if (this.isMany == false) {
        // this.myFiles.push(this.files);
        this.myFiles = this.files ? this.files : [];
      } else {
        this.files?.forEach((item) => {
          item.fileSource = '';
        });
        this.myFiles = this.deepClone(this.files);
      }
    } else {
      this.myFiles = [];
    }
  }
  deepClone(obj: any): any {
    if (typeof obj !== 'object' || obj === null) {
      return obj;
    }
    let clone: any;
    if (Array.isArray(obj)) {
      clone = [];
      for (let i = 0; i < obj.length; i++) {
        clone[i] = this.deepClone(obj[i]);
      }
    } else {
      clone = {};
      for (const key in obj) {
        if (Object.prototype.hasOwnProperty.call(obj, key)) {
          clone[key] = this.deepClone(obj[key]);
        }
      }
    }
    return clone;
  }
  ngAfterViewChecked(): void {
    this.ref.detectChanges();
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      for (var i = 0; i < event.target.files.length; i++) {
        const file = event.target.files[i];
        const reader = new FileReader();
        reader.readAsDataURL(file);
        if (file.size <= 102400) {
          reader.onloadend = () => {
            if (this.isMany == false) {
              this.myFiles = [];
              this.myFiles.push({
                fileSource: reader.result,
                fileName: file.name,
                filePath: '',
                id: 0,
                isDeleted: false,
                PathUrl: reader.result,
              });
            } else {
              this.myFiles.push({
                fileSource: reader.result,
                fileName: file.name,
                filePath: reader.result,
                id: 0,
                sortNumber: this.myFiles.length + 1,
                isDeleted: false,
                PathUrl: reader.result,
              });
            }

            this.OnChangeFile.emit(this.myFiles);
          };
        } else {
          this.tost.warning({
            detail: 'Image than By 100 kb',
            summary: file.name,
            duration: 4000,
          });
        }
      }
    }
    this.myInputVariable.nativeElement.value = '';
  }
  handleConfirmClearAction(item: any): void {
    this.removeFile(item);
  }
  removeFile(item: any) {
    if (item.id > 0) {
      item.isDeleted = true;
      item.filePath = '';
    } else if (item.id == 0) {
      let index = this.myFiles.indexOf(item);
      this.myFiles.splice(index, 1);
    }

    this.OnChangeFile.emit(this.myFiles);
  }
  changeSortNumber(index: number) {
    //True, accept the value
    this.myFiles[index].sortNumber;
    this.ref.detectChanges(); // <<<=== added
    this.getList();
    this.OnChangeFile.emit(this.myFiles);
  }
  getList() {
    return this.myFiles.filter((z) => z.isDeleted == false);
  }

  ClearFiles() {
    this.myFiles = [];
    this.myInputVariable.nativeElement.value = '';
  }
}
