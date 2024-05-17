import pygame
import sys
import random  # Import the random module

# Initialize Pygame
pygame.init()

# Screen dimensions
SCREEN_WIDTH = 800
SCREEN_HEIGHT = 600

# Colors
WHITE = (255, 255, 255)
BLACK = (0, 0, 0)

# Load images
character_img = pygame.image.load("character.png")
bullet_img = pygame.image.load("bullet.png")
speed_powerup_img = pygame.image.load("speed.png")

# Game settings
bullet_speed = 5
character_speed = 5
powerup_spawn_time = 5000  # Powerup spawn interval in milliseconds

# Classes
class Character(pygame.sprite.Sprite):
    def __init__(self):
        super().__init__()
        self.image = character_img
        self.rect = self.image.get_rect()
        self.rect.center = (SCREEN_WIDTH // 2, SCREEN_HEIGHT // 2)
        self.bullet_speed = bullet_speed

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

    def shoot(self, direction):
        bullet = Bullet(self.rect.centerx, self.rect.centery, direction, self.bullet_speed)
        all_sprites.add(bullet)
        bullets.add(bullet)

class Bullet(pygame.sprite.Sprite):
    def __init__(self, x, y, direction, speed):
        super().__init__()
        self.image = bullet_img
        self.rect = self.image.get_rect()
        self.rect.center = (x, y)
        self.direction = direction
        self.speed = speed

    def update(self):
        if self.direction == "left":
            self.rect.x -= self.speed
        elif self.direction == "right":
            self.rect.x += self.speed
        elif self.direction == "up":
            self.rect.y -= self.speed
        elif self.direction == "down":
            self.rect.y += self.speed

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

# Initialize character
character = Character()

# Sprite groups
all_sprites = pygame.sprite.Group()
bullets = pygame.sprite.Group()
powerups = pygame.sprite.Group()

all_sprites.add(character)

# Setup screen
screen = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))
pygame.display.set_caption("Shooter Game")

# Clock for controlling frame rate
clock = pygame.time.Clock()

# Powerup timer
pygame.time.set_timer(pygame.USEREVENT, powerup_spawn_time)

# Main game loop
running = True
while running:
    # Event handling
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_a:
                character.shoot("left")
            elif event.key == pygame.K_d:
                character.shoot("right")
            elif event.key == pygame.K_w:
                character.shoot("up")
            elif event.key == pygame.K_s:
                character.shoot("down")
        elif event.type == pygame.USEREVENT:
            # Spawn a speed powerup at a random position
            x = random.randint(0, SCREEN_WIDTH)
            y = random.randint(0, SCREEN_HEIGHT)
            powerup = SpeedPowerup(x, y)
            all_sprites.add(powerup)
            powerups.add(powerup)

    # Update
    keys_pressed = pygame.key.get_pressed()
    character.update(keys_pressed)
    bullets.update()
    powerups.update()

    # Draw / render
    screen.fill(BLACK)
    all_sprites.draw(screen)

    # Flip the display
    pygame.display.flip()

    # Cap the frame rate
    clock.tick(60)

pygame.quit()
sys.exit()
