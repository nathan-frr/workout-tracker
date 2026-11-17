import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { navigationItems } from './navigation-items';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-navigation',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './app-navigation.html',
  styleUrl: './app-navigation.scss',
})
export class AppNavigation {
  protected readonly items = navigationItems;
  private readonly authService = inject(AuthService);
  private router = inject(Router);

  protected readonly currentUser = this.authService.currentUser;

  logout(): void {
    this.authService.logout().subscribe({
      next: () => {
        this.router.navigate(['/login'])
      },
      error: (e) => {
        console.log("Error", e)
      }
    });
  }
}