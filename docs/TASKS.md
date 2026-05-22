# Tasks — Sprint hiện tại

> Focus: **Phase 0 — Foundation**. Chỉ giữ task của sprint hiện tại ở đây. Task phase tương lai nằm trong [ROADMAP.md](ROADMAP.md).

## Đang làm
- [ ] Setup Player GameObject + Camera trong `SampleScene.unity` (manual trong Unity Editor — xem hướng dẫn dưới)

## To do (next)
- [ ] **Setup map architecture** (xem hướng dẫn bên dưới):
  - [ ] Rename `SampleScene.unity` → `Gameplay.unity` trong Unity Editor
  - [ ] Tạo folder: `Assets/Prefabs/Maps/`, `Assets/Data/Maps/`, `Assets/Tiles/`
  - [ ] Tạo `Tile_Mountain.asset` từ sprite `mountain.png`
  - [ ] Tạo `Palette_Mountain.asset` (Tile Palette window)
  - [ ] Tạo `Map_LuyenKhi.prefab` (Grid + 3 Tilemap + Bounds, vẽ tường biên)
  - [ ] Config Physics 2D collision matrix (xem `docs/SYSTEMS.md → Map architecture`)
- [ ] `Enemy.cs`: chase player, có HP
- [ ] `EnemySpawner.cs`: spawn vòng quanh player
- [ ] Folders còn lại sẽ tạo khi cần: `Enemy/`, `Combat/`, `UI/`, `Data/Skills/`

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

## Hướng dẫn setup map architecture (làm trong Unity Editor)

> Tham khảo `docs/SYSTEMS.md → Map architecture` cho lý do thiết kế.

**1. Rename scene**:
- Project window → `Assets/Scenes/SampleScene.unity` → F2 → rename `Gameplay`.
- Nếu Build Settings có ref → fix lại.

**2. Tạo folders** (Project window, right-click → Create → Folder):
- `Assets/Prefabs/Maps/`
- `Assets/Data/Maps/`
- `Assets/Tiles/`

**3. Tạo Tile asset từ mountain**:
- Right-click `Assets/Sprites/mountain.png` → **Create → 2D → Tiles → Tile**
- Lưu vào `Assets/Tiles/Tile_Mountain.asset`.
- Inspector → gán sprite `moutain_0` vào field `Sprite`.

**4. Tạo Tile Palette**:
- `Window → 2D → Tile Palette` → **Create New Palette** → tên `Palette_Mountain`, lưu vào `Assets/Tiles/`.
- Cell Size: **Manual**, value `(3.58, 2.53, 0)` (để mountain khít).
- Kéo `Tile_Mountain.asset` vào palette grid.

**5. Tạo Map prefab**:
- Trong `Gameplay.unity`: `GameObject → 2D Object → Tilemap → Rectangular` → đặt tên `Map_LuyenKhi`.
- Sửa `Grid → Cell Size` = `(3.58, 2.53, 0)`.
- Rename child Tilemap thành `Tilemap_Walls`. Set:
  - Sorting Layer: `Entities` (tạm — sau chuyển `DecorationBelow` nếu cần)
  - Layer (GameObject layer): `Wall`
  - Add `Tilemap Collider 2D` → tick **Used By Composite**
  - Add `Composite Collider 2D` (tự thêm Rigidbody2D → set `Body Type = Static`)
- Duplicate Tilemap 2 lần → đổi tên `Tilemap_Ground` (sorting `Ground`, xóa collider) và `Tilemap_DecoAbove` (sorting `DecorationAbove`, xóa collider).
- Thêm empty child `Bounds` với `BoxCollider2D` → tick `Is Trigger`, size khớp arena.
- Dùng brush trong Tile Palette → vẽ tường mountain dọc biên lên `Tilemap_Walls`.
- Kéo `Map_LuyenKhi` từ Hierarchy về `Assets/Prefabs/Maps/` để thành prefab.

**6. Config Physics 2D matrix**:
- `Edit → Project Settings → Physics 2D → Layer Collision Matrix`.
- Untick các cặp ghi trong `docs/SYSTEMS.md → Physics Layers`.

**7. Gán Player vào layer `Player`**:
- Mở `Player` GameObject → Inspector top → Layer dropdown → `Player`.

---

## Ghi chú
- Game.cs hiện tại chỉ là placeholder — sẽ refactor thành `GameManager.cs` trong `Systems/`.
- Input System đã được tạo (`Assets/InputSystem_Actions.inputactions`) — dùng lại, đừng tạo mới.
- Sorting Layers + Physics Layers đã setup sẵn trong `ProjectSettings/TagManager.asset` — không cần thêm tay.
