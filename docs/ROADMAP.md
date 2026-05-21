# Roadmap

Tracking theo phase. Tick `[x]` khi xong. Chi tiết task hiện tại nằm trong [TASKS.md](TASKS.md).

---

## Phase 0 — Foundation
Mục tiêu: dự án chạy được, có player di chuyển + enemy đuổi theo.

- [ ] Cấu trúc thư mục `Assets/Scripts/` (Player, Enemy, Combat, Systems, UI, Data)
- [ ] Player controller (Input System đã có sẵn `InputSystem_Actions.inputactions`)
- [ ] Camera follow
- [ ] Enemy AI cơ bản (đuổi theo player)
- [ ] Va chạm + dame
- [ ] Scene `Game` setup

## Phase 1 — MVP Survivor
Mục tiêu: 1 run chơi được từ đầu đến chết, có level up.

- [ ] Player HP + UI HP bar
- [ ] Auto-attack 1 skill (phi kiếm cơ bản)
- [ ] Enemy spawner theo wave/thời gian
- [ ] XP gem rơi khi enemy chết
- [ ] Pickup XP + level up
- [ ] Upgrade choice UI (chọn 1 trong 3)
- [ ] Timer + Game over screen

## Phase 2 — Layer tu tiên
Mục tiêu: phân biệt game này với Vampire Survivors clone.

- [ ] Hệ thống cảnh giới (state machine: Luyện Khí → Trúc Cơ → ...)
- [ ] UI cảnh giới + progress bar
- [ ] 3-5 công pháp đầu tiên (kiếm, phù, đan, thân, thần thông)
- [ ] Thuộc tính ngũ hành cho công pháp + enemy
- [ ] Synergy hệ thống (combo công pháp cùng hành)
- [ ] Đột phá cảnh giới (mini-event hoặc boss tâm ma)
- [ ] Linh thạch drop + meta currency persistence

## Phase 3 — Content & polish
- [ ] 5+ enemy types (theo chủ đề)
- [ ] 2-3 biome / map
- [ ] Boss theo cảnh giới
- [ ] Meta progression: linh căn (starting bonus)
- [ ] Tông môn unlock system

## Phase 4 — Game feel & ship
- [ ] VFX, screen shake, hit pause
- [ ] Audio (SFX + nhạc nền)
- [ ] Balance pass
- [ ] Save system
- [ ] Settings menu
- [ ] Build & publish target (Steam? itch.io?)
