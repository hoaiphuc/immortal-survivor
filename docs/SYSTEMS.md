# Systems — Công thức & số liệu

> Điền dần khi thiết kế từng hệ thống. Mục tiêu: 1 nơi duy nhất để tra balance numbers.

---

## Map architecture

**Pattern**: 1 scene gameplay duy nhất + map là Prefab + ScriptableObject mô tả run config.

### Cấu trúc thư mục
```
Assets/
  Scenes/
    Bootstrap.unity        # Init persistent systems, load Gameplay additively
    MainMenu.unity         # (Phase 1+)
    Gameplay.unity         # PERSISTENT: Player, Camera, UI, GameManager
  Prefabs/Maps/
    Map_LuyenKhi.prefab    # Tilemap painted + bounds + spawn anchors
  Data/Maps/
    MapData_LuyenKhi.asset # SO: ref prefab + wave config + duration + biome
  Tiles/
    Palette_Mountain.asset # Tile palettes dùng chung nhiều map
```

### Map prefab — cấu trúc bên trong
```
Map_LuyenKhi (root, transform 0,0,0)
├── Grid
│   ├── Tilemap_Ground          # sorting "Ground", no collider
│   ├── Tilemap_Walls           # TilemapCollider2D + CompositeCollider2D + Rigidbody2D Static, layer "Wall"
│   └── Tilemap_DecoAbove       # sorting "DecorationAbove"
├── Bounds (BoxCollider2D isTrigger)   # camera clamp + spawn area
├── SpawnAnchors (empty children)      # boss/NPC vị trí cố định
└── BiomeLighting (optional)            # URP 2D Light
```

### Quy tắc
- Player **không** nằm trong map prefab — Player ở `Gameplay.unity` (persistent).
- Spawn enemy logic **không** ở map prefab — `EnemySpawner` đọc từ `MapData.waves`.
- Bounds đọc từ collider child `Bounds`, không hard-code trong code.
- Mọi map prefab pivot tại (0,0,0) để stack consistent.

### MapData ScriptableObject (Phase 3 mới làm)
```csharp
[CreateAssetMenu(menuName = "Immortal/MapData")]
public class MapData : ScriptableObject
{
    public string displayName;
    public GameObject mapPrefab;
    public float runDuration = 600f;
    public WaveConfig[] waves;
    public AudioClip music;
    public Color ambientTint = Color.white;
    // Phase 2: RealmRange minRealm; ElementBias bias;
}
```

### Sorting Layers (đã setup trong `ProjectSettings/TagManager.asset`)
`Default → Ground → DecorationBelow → Entities → DecorationAbove → UI_World`

### Physics Layers (đã setup)
`Player, Enemy, Wall, Pickup, PlayerProjectile, EnemyProjectile`

Collision matrix (cần config trong `Edit → Project Settings → Physics 2D`):
- `EnemyProjectile` ✗ `Enemy` (tự bắn nhau)
- `PlayerProjectile` ✗ `Player`
- `Pickup` ✗ `Enemy`, ✗ `Wall`, ✗ `PlayerProjectile`, ✗ `EnemyProjectile`
- `PlayerProjectile` ✗ `EnemyProjectile` (đạn xuyên qua nhau)

### Roadmap thực hiện
| Phase | Việc |
|---|---|
| Phase 0 | Tạo `Map_LuyenKhi.prefab` (chưa cần SO). Đặt Tilemap painted trong đó. |
| Phase 3 | Tạo `MapData` SO + `MapManager.cs`. Refactor load map qua SO. |
| Phase 4 | Cân nhắc Addressables nếu >5 map. |

---

## Cảnh giới

| Cảnh giới | XP cần | Slot công pháp | Slot passive | Ghi chú |
|---|---|---|---|---|
| Luyện Khí | 0 | 2 | 1 | Khởi đầu |
| Trúc Cơ | TBD | 3 | 2 | Đột phá lần 1 |
| Kim Đan | TBD | 4 | 3 | |
| Nguyên Anh | TBD | 5 | 4 | |
| Hóa Thần | TBD | 6 | 5 | |
| Luyện Hư | TBD | 6 | 6 | |
| Đại Thừa | TBD | 7 | 7 | |
| Phi Thăng | — | — | — | End run |

Đột phá: khi đủ XP → trigger sự kiện. Có thể fail → mất % HP / debuff tạm.

## XP curve
TBD — đề xuất ban đầu: `xp(level) = 10 * level^1.5`.

## Damage formula
TBD — đề xuất: `dame = base * (1 + atk%) * elemental_multiplier`.

## Ngũ hành — Tương sinh / Tương khắc
- **Tương sinh** (bonus +20% dame): Mộc → Hỏa → Thổ → Kim → Thủy → Mộc.
- **Tương khắc** (resistance -20%): Kim khắc Mộc, Mộc khắc Thổ, Thổ khắc Thủy, Thủy khắc Hỏa, Hỏa khắc Kim.

## Công pháp — Stats template
Mỗi công pháp ScriptableObject:
- Tên
- Loại (kiếm / phù / đan / thân / thần thông)
- Ngũ hành
- Base dame
- Cooldown / fire rate
- Số mục tiêu (projectile count / AoE radius)
- Scaling theo cảnh giới
- Level cap (thường 5-8)
- Upgrade path mỗi level

## Enemy — Stats template
- HP
- Dame
- Speed
- Loại (yêu thú thường / yêu tướng / yêu vương)
- Ngũ hành
- XP drop
- Linh thạch drop rate

## Currency
- **Linh khí**: in-run XP. Drop 1-5 mỗi enemy thường.
- **Linh thạch**: meta. Drop hiếm (1% enemy thường, 100% boss).
- **Đan dược**: consumable, mang vào run trước.
