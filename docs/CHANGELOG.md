# Changelog

Ghi lại tiến độ theo ngày. Format: ngắn gọn, gạch đầu dòng.

---

## 2026-05-23
- Chốt **Map architecture**: Prefab-per-map + MapData ScriptableObject + 1 Gameplay scene persistent. Chi tiết: `docs/SYSTEMS.md → Map architecture`.
- Setup `ProjectSettings/TagManager.asset`: thêm Sorting Layers (Ground/DecorationBelow/Entities/DecorationAbove/UI_World) + Physics Layers (Player/Enemy/Wall/Pickup/PlayerProjectile/EnemyProjectile).
- Thêm task setup map architecture vào `docs/TASKS.md` (manual steps trong Unity Editor).

## 2026-05-21
- Khởi tạo docs/: GDD, ROADMAP, TASKS, SYSTEMS, CHANGELOG.
- Dự án Unity rỗng (chỉ có Game.cs placeholder + Input System mặc định).
