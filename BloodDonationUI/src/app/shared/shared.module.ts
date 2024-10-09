import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from "./angular-material/angular-material.module";
@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        HttpClientModule,
        ReactiveFormsModule,
        BrowserModule,
        BrowserAnimationsModule,
        AngularMaterialModule
    ],
    exports: [
        CommonModule,
        HttpClientModule,
        ReactiveFormsModule,
        BrowserModule,
        BrowserAnimationsModule,
        AngularMaterialModule
    ]
})
export class SharedModule { }