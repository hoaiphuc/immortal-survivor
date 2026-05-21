# Systems — Công thức & số liệu

> Điền dần khi thiết kế từng hệ thống. Mục tiêu: 1 nơi duy nhất để tra balance numbers.

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
