import { NgModule } from "@angular/core";
import { AngularMaterialModule } from "./angular-material/angular-material.module";
import { HomeComponent } from "./navigation/home/home.component";
import { NavigationModule } from "./navigation/navigation.module";
import { CommonModule } from "@angular/common";

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
        AngularMaterialModule,
        NavigationModule,
        CommonModule
    ],
    providers: [

    ],
})
export class ComponentsModule { }