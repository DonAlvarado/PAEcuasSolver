function result = mas(m, k, x0, v0)

% ================= PARAMETROS =================
omega = sqrt(k/m);

A = sqrt(x0^2 + (v0/omega)^2);
phi = atan2(v0/omega, x0);

t = linspace(0, 10, 200);
x = A * cos(omega*t - phi);

% ================= RESULT =================
result.omega = omega;
result.A = A;
result.phi = phi;
result.tipo = "MAS";

result.t = t;
result.x = x;

% ================= JSON OUTPUT =================
json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");

end