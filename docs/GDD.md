# Game Design Document — Immortal Survivor

## Tóm tắt
Game survivor (top-down, auto-attack, roguelite) chủ đề **tu tiên / xianxia**. Người chơi là một tu sĩ sống sót trước sóng yêu thú, đột phá cảnh giới qua từng run.

## Pillars
1. **Combat sướng tay**: auto-attack, screen-clearing, level-up choices.
2. **Layer tu tiên**: cảnh giới, công pháp, ngũ hành — thay thế weapon system phẳng của Vampire Survivors bằng hệ thống có chiều sâu.
3. **Meta progression**: linh căn, tông môn, đan dược tích lũy giữa các run.

## Core loop
- **Trong run (5-20 phút)**: di chuyển → auto-attack → nhặt linh khí (XP) → level up → chọn công pháp → đột phá cảnh giới khi đủ điều kiện → boss → tiếp tục hoặc kết thúc.
- **Ngoài run**: dùng linh thạch tích lũy để mở khóa linh căn / công pháp / tông môn mới.

## Theme & setting
- Bối cảnh: hạ giới đang loạn, yêu khí tràn ra từ Hắc Vụ Sơn. Tu sĩ phải sống sót và đột phá để phi thăng.
- Phong cách art: 2D top-down (chưa chốt pixel hay vector — quyết khi có sprite mẫu).

## Hệ thống chính (chi tiết trong SYSTEMS.md)

### Cảnh giới
Luyện Khí → Trúc Cơ → Kim Đan → Nguyên Anh → Hóa Thần → Luyện Hư → Đại Thừa → Phi Thăng.
Mỗi cảnh giới = milestone trong run, mở khóa slot công pháp / passive mới. Đột phá có thể fail (mini boss "tâm ma").

### Công pháp (thay cho "weapon")
- **Kiếm pháp**: phi kiếm, kiếm khí, kiếm trận.
- **Phù lục**: nổ AoE, debuff.
- **Đan dược**: heal, buff tạm thời.
- **Thân pháp**: dash, evasion, tốc độ.
- **Thần thông**: ultimate có cooldown dài.

### Ngũ hành
Kim / Mộc / Thủy / Hỏa / Thổ. Mỗi công pháp có thuộc tính. Combo cùng hành → bonus. Tương sinh tương khắc với yêu thú.

### Currency
- **Linh khí** (trong run): XP để level up.
- **Linh thạch** (meta): mua upgrade vĩnh viễn.
- **Đan dược** (consumable): mang vào run.

## Out of scope (lúc đầu)
- Multiplayer.
- Story branching phức tạp.
- Crafting sâu.

## Câu hỏi mở (cần chốt sau)
- Chính đạo / Ma đạo branching?
- Tông môn có gameplay riêng hay chỉ là cosmetic + bonus?
- Pixel art hay vector?
