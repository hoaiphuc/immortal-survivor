# Tasks — Sprint hiện tại

> Focus: **Phase 0 — Foundation**. Chỉ giữ task của sprint hiện tại ở đây. Task phase tương lai nằm trong [ROADMAP.md](ROADMAP.md).

## Đang làm
- [ ] Setup Player GameObject + Camera trong `SampleScene.unity` (manual trong Unity Editor — xem hướng dẫn dưới)

## To do (next)
- [ ] `Enemy.cs`: chase player, có HP
- [ ] `EnemySpawner.cs`: spawn vòng quanh player
- [ ] Folders còn lại sẽ tạo khi cần: `Enemy/`, `Combat/`, `UI/`, `Data/`

## Done
- [x] `Assets/Scripts/Player/PlayerController.cs` — move bằng Input System (WASD / left stick), Rigidbody2D-based
- [x] `Assets/Scripts/Systems/CameraFollow.cs` — SmoothDamp follow target

---

## Hướng dẫn setup scene (làm trong Unity Editor)

Mở `Assets/Scenes/SampleScene.unity`:

**Tạo Player**:
1. Hierarchy → right-click → Create Empty → đặt tên `Player`.
2. Add Component → `Rigidbody 2D`:
   - Body Type: **Dynamic**
   - Gravity Scale: **0**
   - Constraints: tick **Freeze Rotation Z**
   - Interpolate: **Interpolate** (để movement mượt)
3. Add Component → `Circle Collider 2D` (hoặc Box).
4. Add Component → `Sprite Renderer` → kéo bất kỳ sprite nào vào (hoặc dùng `Knob` mặc định của Unity).
5. Add Component → kéo `PlayerController` script vào → set `Move Speed = 5`.

**Setup Camera**:
1. Chọn `Main Camera` trong Hierarchy.
2. Add Component → kéo `CameraFollow` script vào.
3. Kéo Player từ Hierarchy vào field `Target`.
4. Đảm bảo Camera position Z = `-10` (mặc định 2D).

**Test**:
- Bấm Play. WASD hoặc arrow keys → player di chuyển, camera follow.

---

## Ghi chú
- Game.cs hiện tại chỉ là placeholder — sẽ refactor thành `GameManager.cs` trong `Systems/`.
- Input System đã được tạo (`Assets/InputSystem_Actions.inputactions`) — dùng lại, đừng tạo mới.
