function result = mvf(m, k, b, F0, wf, x0, v0)

% ================= TIEMPO =================
t = linspace(0,10,500);
dt = t(2) - t(1);

% ================= PARÁMETROS =================
lambda = b/(2*m);
omega0 = sqrt(k/m);
omega_f = wf;

a = b/m;
c = k/m;
f = F0/m;

% ================= PARTICULAR =================
den = (c - wf^2)^2 + (a*wf)^2;

A = f*(c - wf^2)/den;
B = -f*a*wf/den;

xp = A*sin(wf*t) + B*cos(wf*t);

xp0 = xp(1);
xp0p = (xp(2) - xp(1)) / dt;

% ================= HOMOGÉNEA =================
disc = omega0^2 - lambda^2;

if disc > 0
    wd = sqrt(disc);

    C1 = x0 - xp0;
    C2 = (v0 - xp0p + lambda*C1)/wd;

    xh = exp(-lambda*t).*(C1*cos(wd*t) + C2*sin(wd*t));

elseif abs(disc) < 1e-10
    C1 = x0 - xp0;
    C2 = v0 - xp0p + lambda*C1;

    xh = (C1 + C2*t).*exp(-lambda*t);

else
    s = sqrt(-disc);

    r1 = -lambda + s;
    r2 = -lambda - s;

    C1 = ((v0 - xp0p) - r2*(x0 - xp0))/(r1 - r2);
    C2 = (x0 - xp0) - C1;

    xh = C1*exp(r1*t) + C2*exp(r2*t);
end

% ================= TOTAL =================
x = xh + xp;

% ================= RESULT STRUCT =================
result.lambda = lambda;
result.omega0 = omega0;
result.omega_f = omega_f;

result.F0 = F0;

result.A = A;
result.B = B;

result.C1 = C1;
result.C2 = C2;

result.t = t;
result.x = x;

if disc > 0
    eq_h = sprintf("e^{-%.4ft}(%.4f cos(%.4ft) + %.4f sin(%.4ft))", ...
        lambda, C1, wd, C2, wd);
elseif abs(disc) < 1e-10
    eq_h = sprintf("(%.4f + %.4ft)e^{-%.4ft}", C1, C2, lambda);
else
    eq_h = sprintf("%.4fe^{%.4ft} + %.4fe^{%.4ft}", C1, r1, C2, r2);
end

eq_p = sprintf("%.4f sin(%.4ft) + %.4f cos(%.4ft)", A, wf, B, wf);

result.equation = strcat("x(t) = ", eq_h, " + ", eq_p);

% ================= OUTPUT COMPATIBLE CON TU PARSER =================
json = jsonencode(result);

disp("JSON_START");
fprintf("%s\n", json);
disp("JSON_END");

end