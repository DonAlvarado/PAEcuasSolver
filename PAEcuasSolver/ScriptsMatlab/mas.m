function result = mas(m, k, x0, v0);

% ================= PARAMETROS =================
omega = sqrt(k/m);

A = sqrt(x0^2 + (v0/omega)^2);
phi = atan2(v0/omega, x0);

t = linspace(0, 10, 200);
x = A * cos(omega*t - phi);

tipo = "MAS";

% ================= JSON OUTPUT =================
result.lambda = lambda;
result.omega = omega;
result.tipo = tipo;

result.C1 = C1;
result.C2 = C2;

if exist('r1','var')
    result.r1 = r1;
    result.r2 = r2;
end

result.t = t;
result.x = x;

json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");