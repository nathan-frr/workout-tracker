import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { navigationItems } from './navigation-items';

@Component({
  selector: 'app-navigation',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './app-navigation.html',
  styleUrl: './app-navigation.scss',
})
export class AppNavigation {
  protected readonly items = navigationItems;
}