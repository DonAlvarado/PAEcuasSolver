function result = rlc_i(L, R, C, E0, w, i0, di0)

% PARAMETROS
lambda = R/(2*L);
omega = sqrt(1/(L*C));

t = linspace(0, 10, 200);

% Fuerza equivalente (derivada de E)
F0 = (E0 * w) / L;

A = F0 / sqrt((omega^2 - w^2)^2 + (2*lambda*w)^2);
phi = atan2(2*lambda*w, (omega^2 - w^2));

i = A * cos(w*t - phi);

% RESULT
result.lambda = lambda;
result.omega = omega;

result.E0 = E0;
result.w = w;

result.A = A;
result.phi = phi;

result.equation = sprintf("i(t) = %.4f*cos(%.4ft - %.4f)", A, w, phi);

result.t = t;
result.x = i;

% JSON
json = jsonencode(result);

fprintf("JSON_START\n");
fprintf("%s\n", json);
fprintf("JSON_END\n");

end