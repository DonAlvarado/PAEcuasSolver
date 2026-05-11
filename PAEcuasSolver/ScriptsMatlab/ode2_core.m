function result = ode2_core(a, b, c, f_handle, t, x0, v0)

% ================= PARÁMETROS =================
lambda = b/(2*a);
omega0 = sqrt(c/a);

dt = t(2) - t(1);

% ================= FORZAMIENTO =================
fp = f_handle(t);
fp = fp(:)';

% ================= PARTICULAR =================
xp = (1/c) * fp;
xp = xp(:)';

xp0 = xp(1);

if length(xp) < 2
    xp0p = 0;
else
    xp0p = (xp(2) - xp(1)) / dt;
end

% valor particular (SIEMPRE constante en tu modelo RLC actual)
xp_const = xp(1);

% ================= HOMOGÉNEA =================
disc = omega0^2 - lambda^2;

if disc > 0
    % SUBAMORTIGUADO
    wd = sqrt(disc);

    C1 = x0 - xp0;
    C2 = (v0 - xp0p + lambda*C1) / wd;

    xh = exp(-lambda*t).*(C1*cos(wd*t) + C2*sin(wd*t));

    eq_h = sprintf("e^{-%.4ft}(-%.4f cos(%.4ft) + -%.4f sin(%.4ft))", ...
        lambda, -C1, wd, -C2, wd);

elseif disc == 0
    % CRÍTICO
    C1 = x0 - xp0;
    C2 = v0 - xp0p + lambda*C1;

    xh = (C1 + C2*t).*exp(-lambda*t);

    eq_h = sprintf("(%.4f + %.4ft)e^{-%.4ft}", C1, C2, lambda);

else
    % SOBREAMORTIGUADO
    r1 = -lambda + sqrt(-disc);
    r2 = -lambda - sqrt(-disc);

    M = [1 1; r1 r2];
    Y = [x0 - xp0; v0 - xp0p];

    sol = M\Y;

    C1 = sol(1);
    C2 = sol(2);

    xh = C1*exp(r1*t) + C2*exp(r2*t);

    eq_h = sprintf("%.4fe^{%.4ft} + %.4fe^{%.4ft}", C1, r1, C2, r2);
end

% ================= SOLUCIÓN TOTAL =================
x = xh + xp;

% ================= ECUACIÓN FINAL LIMPIA =================
if max(abs(fp - fp(1))) < 1e-6
    % fuerza constante
    eq_p = sprintf("%.4f", xp_const);
else
    % forzamiento no constante
    eq_p = "xp(t)";
end

result.equation = strcat("x(t) = ", eq_h, " + ", eq_p);

% ================= OUTPUT NUMÉRICO =================
result.lambda = lambda;
result.omega = omega0;

result.C1 = C1;
result.C2 = C2;

result.t = t;
result.x = x;

end