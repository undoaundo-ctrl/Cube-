global rotate3
section .text
; void rotate3(float* p, float* m)  p = M * p (m is 3x3 row-major)
rotate3:
    movss xmm0,[rdi]
    movss xmm1,[rdi+4]
    movss xmm2,[rdi+8]
    movss xmm3,[rsi]
    mulss xmm3,xmm0
    movss xmm4,[rsi+4]
    mulss xmm4,xmm1
    addss xmm3,xmm4
    movss xmm4,[rsi+8]
    mulss xmm4,xmm2
    addss xmm3,xmm4
    movss xmm5,[rsi+12]
    mulss xmm5,xmm0
    movss xmm4,[rsi+16]
    mulss xmm4,xmm1
    addss xmm5,xmm4
    movss xmm4,[rsi+20]
    mulss xmm4,xmm2
    addss xmm5,xmm4
    movss xmm6,[rsi+24]
    mulss xmm6,xmm0
    movss xmm4,[rsi+28]
    mulss xmm4,xmm1
    addss xmm6,xmm4
    movss xmm4,[rsi+32]
    mulss xmm4,xmm2
    addss xmm6,xmm4
    movss [rdi],xmm3
    movss [rdi+4],xmm5
    movss [rdi+8],xmm6
    ret
