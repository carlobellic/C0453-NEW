import pygame
import sys
import random
import math
import time

# Initialize Pygame
pygame.init()

# Screen dimensions
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600

# Colors
WHITE = (255, 255, 255)
BLACK = (0, 0, 0)
RED = (255, 0, 0)
GREEN = (0, 255, 0)

# Load images and scale them down
character_img = pygame.image.load("character.png")
character_img = pygame.transform.scale(character_img, (50, 50))  # Scale character image

bullet_img = pygame.image.load("bullet.png")
bullet_img = pygame.transform.scale(bullet_img, (10, 10))  # Scale bullet image

speed_powerup_img = pygame.image.load("speed.png")
speed_powerup_img = pygame.transform.scale(speed_powerup_img, (20, 20))  # Scale powerup image

background_img = pygame.image.load("stone.png")  # Load background image
background_img = pygame.transform.scale(background_img, (SCREEN_WIDTH, SCREEN_HEIGHT))  # Scale background image to fit screen

alien_img = pygame.image.load("alien.png")  # Load enemy image
alien_img = pygame.transform.scale(alien_img, (40, 40))  # Scale enemy image

# Game settings
bullet_speed = 5
character_speed = 5
initial_enemy_speed = 1.25  # 25% of character speed
wave_enemy_speed_increase = 0.25  # 5% of character speed
powerup_spawn_time = 45000  # Powerup spawn interval in milliseconds (45 seconds)
enemy_spawn_time = 10000  # Enemy spawn interval in milliseconds (10 seconds)
waves_total = 5
enemies_per_wave = 5
damage_cooldown = 2000  # Cooldown in milliseconds (2 seconds)

# Fonts
font = pygame.font.SysFont(None, 36)

# Classes
class Character(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = character_img
        self.rect = self.image.get_rect()
        self.rect.center = (SCREEN_WIDTH // 2, SCREEN_HEIGHT // 2)
        self.bullet_speed = bullet_speed
        self.health = 100
        self.last_hit_time = 0  # Timestamp of the last hit

    def update(self, keys_pressed):
        if keys_pressed[pygame.K_LEFT]:
            self.rect.x -= character_speed
        if keys_pressed[pygame.K_RIGHT]:
            self.rect.x += character_speed
        if keys_pressed[pygame.K_UP]:
            self.rect.y -= character_speed
        if keys_pressed[pygame.K_DOWN]:
            self.rect.y += character_speed

        # Keep character within screen bounds
        self.rect.x = max(0, min(self.rect.x, SCREEN_WIDTH - self.rect.width))
        self.rect.y = max(0, min(self.rect.y, SCREEN_HEIGHT - self.rect.height))

    def shoot(self, mouse_pos):
        direction = pygame.math.Vector2(mouse_pos) - pygame.math.Vector2(self.rect.center)
        direction = direction.normalize()
        bullet = Bullet(self.rect.centerx, self.rect.centery, direction, self.bullet_speed)
        all_sprites.add(bullet)
        bullets.add(bullet)

    def take_damage(self):
        current_time = pygame.time.get_ticks()
        if current_time - self.last_hit_time > damage_cooldown:
            self.health -= 1
            self.last_hit_time = current_time
            if self.health <= 0:
                global running
                running = False

    def draw_health_bar(self, surface):
        # Calculate health bar dimensions
        bar_width = 50
        bar_height = 5
        bar_x = self.rect.centerx - bar_width // 2
        bar_y = self.rect.y - bar_height - 5
        fill = (self.health / 100) * bar_width

        # Draw the health bar
        outline_rect = pygame.Rect(bar_x, bar_y, bar_width, bar_height)
        fill_rect = pygame.Rect(bar_x, bar_y, fill, bar_height)
        pygame.draw.rect(surface, RED, outline_rect)
        pygame.draw.rect(surface, GREEN, fill_rect)

class Bullet(pygame.sprite.Sprite):
    def __init__(self, x, y, direction, speed):
        super().__init__()
        self.image = bullet_img
        self.rect = self.image.get_rect()
        self.rect.center = (x, y)
        self.direction = direction
        self.speed = speed

    def update(self):
        self.rect.x += self.direction.x * self.speed
        self.rect.y += self.direction.y * self.speed

        # Remove bullet if it goes off screen
        if self.rect.right < 0 or self.rect.left > SCREEN_WIDTH or self.rect.bottom < 0 or self.rect.top > SCREEN_HEIGHT:
            self.kill()

class SpeedPowerup(pygame.sprite.Sprite):
    def __init__(self, x, y):
        super().__init__()
        self.image = speed_powerup_img
        self.rect = self.image.get_rect()
        self.rect.center = (x, y)

    def update(self):
        # Collision detection with character
        if pygame.sprite.collide_rect(self, character):
            character.bullet_speed += 2
            self.kill()

class Enemy(pygame.sprite.Sprite):
    def __init__(self, x, y, speed):
        super().__init__()
        self.image = alien_img
        self.rect = self.image.get_rect()
        self.rect.center = (x, y)
        self.speed = speed

    def update(self):
        # Move the enemy towards the character
        if self.rect.x < character.rect.x:
            self.rect.x += self.speed
        if self.rect.x > character.rect.x:
            self.rect.x -= self.speed
        if self.rect.y < character.rect.y:
            self.rect.y += self.speed
        if self.rect.y > character.rect.y:
            self.rect.y -= self.speed

        # Remove enemy if it collides with the character
        if pygame.sprite.collide_rect(self, character):
            character.take_damage()
            self.kill()

# Initialize character
character = Character()

# Sprite groups
all_sprites = pygame.sprite.Group()
bullets = pygame.sprite.Group()
powerups = pygame.sprite.Group()
enemies = pygame.sprite.Group()

all_sprites.add(character)

# Setup screen
screen = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))
pygame.display.set_caption("Shooter Game")

# Clock for controlling frame rate
clock = pygame.time.Clock()

# Powerup timer
pygame.time.set_timer(pygame.USEREVENT, powerup_spawn_time)
# Enemy spawn timer
pygame.time.set_timer(pygame.USEREVENT + 1, enemy_spawn_time)

# Game state
wave = 1
enemy_speed = initial_enemy_speed
enemies_spawned = 0

# Main game loop
running = True
while running:
    # Event handling
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.MOUSEBUTTONDOWN:
            if event.button == 1:  # Left mouse button
                mouse_pos = pygame.mouse.get_pos()
                character.shoot(mouse_pos)
        elif event.type == pygame.USEREVENT:
            # Spawn a speed powerup at a random position
            x = random.randint(0, SCREEN_WIDTH)
            y = random.randint(0, SCREEN_HEIGHT)
            powerup = SpeedPowerup(x, y)
            all_sprites.add(powerup)
            powerups.add(powerup)
        elif event.type == pygame.USEREVENT + 1:
            if wave <= waves_total and enemies_spawned < enemies_per_wave:
                # Spawn an enemy at a random edge of the screen
                edge = random.choice(["top", "bottom", "left", "right"])
                if edge == "top":
                    x = random.randint(0, SCREEN_WIDTH)
                    y = 0
                elif edge == "bottom":
                    x = random.randint(0, SCREEN_WIDTH)
                    y = SCREEN_HEIGHT
                elif edge == "left":
                    x = 0
                    y = random.randint(0, SCREEN_HEIGHT)
                else:
                    x = SCREEN_WIDTH
                    y = random.randint(0, SCREEN_HEIGHT)

                enemy = Enemy(x, y, enemy_speed)
                all_sprites.add(enemy)
                enemies.add(enemy)
                enemies_spawned += 1

            if enemies_spawned >= enemies_per_wave and len(enemies) == 0:
                wave += 1
                enemies_spawned = 0
                enemy_speed += wave_enemy_speed_increase

    # Update
    keys_pressed = pygame.key.get_pressed()
    character.update(keys_pressed)
    bullets.update()
    powerups.update()
    enemies.update()

    # Check for collisions between bullets and enemies
    for bullet in bullets:
        hits = pygame.sprite.spritecollide(bullet, enemies, True)
        if hits:
            bullet.kill()

    # Draw / render
    screen.blit(background_img, (0, 0))  # Draw background
    all_sprites.draw(screen)
    character.draw_health_bar(screen)

    # Draw wave counter
    wave_text = font.render(f"Wave: {wave}", True, WHITE)
    screen.blit(wave_text, (10, 10))

    # Flip the display
    pygame.display.flip()

    # Cap the frame rate
    clock.tick(60)

pygame.quit()
sys.exit()
