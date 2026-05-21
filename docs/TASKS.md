# Tasks — Sprint hiện tại

> Focus: **Phase 0 — Foundation**. Chỉ giữ task của sprint hiện tại ở đây. Task phase tương lai nằm trong [ROADMAP.md](ROADMAP.md).

## Đang làm
_(chưa có)_

## To do (next)
- [ ] Tạo cấu trúc thư mục `Assets/Scripts/`:
  - `Player/` — controller, stats
  - `Enemy/` — AI, spawner
  - `Combat/` — damage, hitbox, projectile
  - `Systems/` — game state, wave, level up
  - `UI/` — HUD, menus
  - `Data/` — ScriptableObjects (công pháp, enemy stats, cảnh giới)
- [ ] `PlayerController.cs`: move bằng Input System (WASD / left stick)
- [ ] `CameraFollow.cs`: theo player smooth
- [ ] `Enemy.cs`: chase player, có HP
- [ ] `EnemySpawner.cs`: spawn vòng quanh player
- [ ] Setup scene `Game.unity` với player + camera + spawner

## Done
_(chưa có)_

---

## Ghi chú
- Game.cs hiện tại chỉ là placeholder — sẽ refactor thành `GameManager.cs` trong `Systems/`.
- Input System đã được tạo (`Assets/InputSystem_Actions.inputactions`) — dùng lại, đừng tạo mới.
